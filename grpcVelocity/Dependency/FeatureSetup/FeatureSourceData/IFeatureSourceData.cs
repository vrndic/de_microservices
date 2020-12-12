using System.Threading.Tasks;
using Amazon.DynamoDBv2.Model;

namespace grpcVelocity.Dependency.FeatureSetup.FeatureSourceData
{
    public interface IFeatureSourceData
    {
        Task<QueryResponse> GetData(string key);
    }
}
