using System.Text.Json;
using Amazon.DynamoDBv2;
using Dapr.Client;
using grpcVelocity.Dependency.FeatureSetup.FeatureConfiguration;
using grpcVelocity.Dependency.FeatureSetup.FeatureSourceData;
using Microsoft.Extensions.Configuration;

namespace grpcVelocity.Dependency.FeatureSetup
{
    public class DefaultFeatureSetup : IFeatureSetup
    {
        public IConfiguration Configuration { get; set; }
        private readonly IAmazonDynamoDB _dynamoDbConnection;
        private readonly DaprClient _daprClient;
        public DefaultFeatureSetup(IConfiguration configuration)
        {
            Configuration = configuration;

            _dynamoDbConnection = GetDynamoDbClient(configuration);

            _daprClient = GetDaprClient();
        }

        private IAmazonDynamoDB GetDynamoDbClient(IConfiguration configuration)
        {
            var options = configuration.GetAWSOptions();
            return options.CreateServiceClient<IAmazonDynamoDB>();
        }

        private static DaprClient GetDaprClient()
        {
            var jsonOptions = new JsonSerializerOptions()
            {
                PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
                PropertyNameCaseInsensitive = true,
            };

            var client = new DaprClientBuilder()
                .UseJsonSerializationOptions(jsonOptions)
                .Build();
            return client;
        }

        public IFeatureConfiguration GetConfiguration()
        {
            return new DaprStateFeatureConfiguration(Configuration, _daprClient);
        }

        public IFeatureSourceData GetSourceData()
        {
            return new DynamoDbFeatureSourceData(Configuration, _dynamoDbConnection);
        }
    }
}
