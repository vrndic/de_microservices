using System.Collections.Generic;

namespace grpcVelocity.Dependency.FeatureSetup.FeatureConfiguration
{
    public interface IFeatureConfiguration
    {
        List<string> GetConfiguration(string key);
    }
}
