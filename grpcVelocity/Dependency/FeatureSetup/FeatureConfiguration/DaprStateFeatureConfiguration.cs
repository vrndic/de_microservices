using System.Collections.Generic;
using System.Text.Json;
using Dapr.Client;
using grpcVelocity.Dependency.FeatureConfiguration;

namespace grpcVelocity.Dependency.FeatureSetup.FeatureConfiguration
{
    public class DaprStateFeatureConfiguration : IFeatureConfiguration
    {
        private readonly DaprClient _daprClient;
        public DaprStateFeatureConfiguration()
        {
            var jsonSerializerOptions = new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true,
                PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
            };

            _daprClient = new DaprClientBuilder()
                .UseJsonSerializationOptions(jsonSerializerOptions)
                .Build();
        }
        public Dictionary<string, List<string>> GetConfiguration(string key)
        {
            return _daprClient.GetStateAsync<Dictionary<string, List<string>>>("statestore", "velocityList").Result;
        }
    }
}
