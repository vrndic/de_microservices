using grpcVelocity.Dependency.FeatureConfiguration;
using grpcVelocity.Dependency.FeatureSetup.FeatureConfiguration;
using grpcVelocity.Dependency.FeatureSetup.FeatureSourceData;
using grpcVelocity.Dependency.FeatureSourceData;
using Microsoft.Extensions.Configuration;

namespace grpcVelocity.Dependency.FeatureSetup
{
    public class DefaultFeatureSetup : IFeatureSetup
    {
        public IConfiguration Configuration { get; set; }
        public DefaultFeatureSetup(IConfiguration configuration)
        {
            Configuration = configuration;
        }
        public IFeatureConfiguration GetConfiguration()
        {
            return new DaprStateFeatureConfiguration(Configuration);
        }

        public IFeatureSourceData GetSourceData()
        {
            return new DynamoDbFeatureSourceData(Configuration);
        }
    }
}
