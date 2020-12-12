using grpcVelocity.Dependency.FeatureConfiguration;
using grpcVelocity.Dependency.FeatureSetup.FeatureConfiguration;
using grpcVelocity.Dependency.FeatureSetup.FeatureSourceData;
using grpcVelocity.Dependency.FeatureSourceData;

namespace grpcVelocity.Dependency.FeatureSetup
{
    public class DefaultFeatureSetup : IFeatureSetup
    {
        public IFeatureConfiguration GetConfiguration()
        {
            return new DaprStateFeatureConfiguration();
        }

        public IFeatureSourceData GetData()
        {
            return new DynamoDbFeatureSourceData();
        }
    }
}
