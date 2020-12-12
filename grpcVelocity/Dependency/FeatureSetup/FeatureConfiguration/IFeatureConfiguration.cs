using System.Collections.Generic;

namespace grpcVelocity.Dependency.FeatureConfiguration
{
    public interface IFeatureConfiguration
    {
        Dictionary<string, List<string>> GetConfiguration(string key);
    }
}
