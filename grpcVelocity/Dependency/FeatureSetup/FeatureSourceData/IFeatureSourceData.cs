using System.Collections.Generic;
using System.Threading.Tasks;
using Amazon.DynamoDBv2.Model;
using grpcVelocity.Model;

namespace grpcVelocity.Dependency.FeatureSetup.FeatureSourceData
{
    public interface IFeatureSourceData
    {
        List<PhoneTransaction> GetData(string key);
    }
}
