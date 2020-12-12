using grpcVelocity.Dependency.FeatureConfiguration;
using grpcVelocity.Dependency.FeatureSourceData;
using Microsoft.Extensions.Configuration;

namespace grpcVelocity.Dependency.FeatureSetup
{
    public interface IFeatureSetup
    {
        IFeatureConfiguration GetConfiguration();
        IFeatureSourceData GetSourceData();
    }
}
