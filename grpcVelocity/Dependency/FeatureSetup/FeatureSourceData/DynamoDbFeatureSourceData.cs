using System.Collections.Generic;
using System.Threading.Tasks;
using Amazon;
using Amazon.DynamoDBv2;
using Amazon.DynamoDBv2.Model;
using grpcVelocity.Dependency.FeatureSourceData;

namespace grpcVelocity.Dependency.FeatureSetup.FeatureSourceData
{
    public class DynamoDbFeatureSourceData : IFeatureSourceData
    {
        private readonly IAmazonDynamoDB _dynamoDbConnection;
        public DynamoDbFeatureSourceData()
        {
            _dynamoDbConnection = new AmazonDynamoDBClient(RegionEndpoint.EUWest1);
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
