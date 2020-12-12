using grpcVelocity.Dependency.FeatureSetup.FeatureConfiguration;
using grpcVelocity.Dependency.FeatureSetup.FeatureSourceData;
using Microsoft.Extensions.Configuration;

namespace grpcVelocity.Dependency.FeatureSetup
{
    public interface IFeatureSetup
    {
        IFeatureConfiguration GetConfiguration();
        IFeatureSourceData GetSourceData();
    }
}
