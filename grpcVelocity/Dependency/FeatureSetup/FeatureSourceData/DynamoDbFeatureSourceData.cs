using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Amazon.DynamoDBv2;
using Amazon.DynamoDBv2.Model;
using grpcVelocity.Model;
using Microsoft.Extensions.Configuration;

namespace grpcVelocity.Dependency.FeatureSetup.FeatureSourceData
{
    public class DynamoDbFeatureSourceData : IFeatureSourceData
    {
        private readonly IAmazonDynamoDB _dynamoDbConnection;
        public DynamoDbFeatureSourceData(IConfiguration configuration, IAmazonDynamoDB dynamoDbConnection)
        {
            _dynamoDbConnection = dynamoDbConnection;
        }
        public List<PhoneTransaction> GetData(string key)
        {
            var request = new QueryRequest
            {
                TableName = @"dev-nvrndic-db",
                KeyConditionExpression = $"phone_number_hash = :phoneId",
                ExpressionAttributeValues = new Dictionary<string, AttributeValue>
                {
                    {
                        ":phoneId", new AttributeValue
                        {
                            S = key
                        }

                    }
                }
            };

            var response = GetResponseFromDynamoDb(request).Result;

            return response.Items.Select(GeTransaction).ToList();
        }

        private async Task<QueryResponse> GetResponseFromDynamoDb(QueryRequest request)
        {
            return await _dynamoDbConnection.QueryAsync(request);
        }

        public static PhoneTransaction GeTransaction(Dictionary<string, AttributeValue> resultItem)
        {
            var phoneTransaction = new PhoneTransaction();

            foreach (var (key, value) in resultItem)
               
                switch (key)
                {
                    case "phone_number_hash":
                        phoneTransaction.PhoneHash = value.S;
                        break;
                    case "epoch_datetime":
                        phoneTransaction.EpochDatetime = long.Parse(value.N);
                        break;
                    default:
                        throw new KeyNotFoundException($"{key}");
                }
              
            return phoneTransaction;
        }
    }
}
