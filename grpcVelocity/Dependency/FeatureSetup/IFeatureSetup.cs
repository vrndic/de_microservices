using grpcVelocity.Dependency.FeatureConfiguration;
using grpcVelocity.Dependency.FeatureSourceData;

namespace grpcVelocity.Dependency.FeatureSetup
{
    public interface IFeatureSetup
    {
        IFeatureConfiguration GetConfiguration();
        IFeatureSourceData GetData();
    }
}
