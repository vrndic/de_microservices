using System.Threading.Tasks;
using Amazon.DynamoDBv2.Model;

namespace grpcVelocity.Dependency.FeatureSourceData
{
    public interface IFeatureSourceData
    {
        Task<QueryResponse> GetData(string key);
    }
}
