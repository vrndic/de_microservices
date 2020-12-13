using System.Collections.Generic;
using Dapr.Client;
using Microsoft.Extensions.Configuration;

namespace grpcVelocity.Dependency.FeatureSetup.FeatureConfiguration
{
    public class DaprStateFeatureConfiguration : IFeatureConfiguration
    {
        public IConfiguration Configuration { get; set; }
        private readonly DaprClient _daprClient;

        public DaprStateFeatureConfiguration(IConfiguration configuration, DaprClient daprClient)
        {
            Configuration = configuration;
            _daprClient = daprClient;

            //TODO Just for demo
            //AddDemoConfigSetup(_daprClient);
        }

        public List<string> GetConfiguration(string key)
        {
            return _daprClient.GetStateAsync<List<string>>("statestore", "velocityList").Result;
        }

        private static void AddDemoConfigSetup(DaprClient daprClient)
        {
            var redisSetup = new List<string>
            {
                "velocity_1min",
                "velocity_2min",
                "velocity_3min",
                "velocity_4min",
                "velocity_5min",
                "velocity_6min",
                "velocity_7min",
                "velocity_8min",
                "velocity_9min",
                "velocity_10min",
                "velocity_11min",
                "velocity_12min",
                "velocity_13min",
                "velocity_14min",
                "velocity_15min",
                "velocity_16min",
                "velocity_17min",
                "velocity_18min",
                "velocity_19min",
                "velocity_20min"
            };

            daprClient.SaveStateAsync("statestore", "velocityList", redisSetup);
        }
    }
}
