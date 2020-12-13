using System.Collections.Generic;
using System.Threading.Tasks;
using Amazon.DynamoDBv2;
using Amazon.DynamoDBv2.Model;
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
        public async Task<QueryResponse> GetData(string key)
        {
            var request = new QueryRequest
            {
                TableName = "aws-bics-score-qa-global-speed-layer",
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

            return await _dynamoDbConnection.QueryAsync(request);
        }
    }
}
