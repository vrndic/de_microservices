using System.Threading.Tasks;
using DataEngineering.Microservices.Features;
using Grpc.Core;
using grpcVelocity.Dependency.FeatureSetup;
using Microsoft.Extensions.Logging;

namespace grpcVelocity
{
    public class VelocityService : Velocity.VelocityBase
    {
        private readonly ILogger<VelocityService> _logger;
        private readonly IFeatureSetup _featureSetup;
        public VelocityService(ILogger<VelocityService> logger, IFeatureSetup featureSetup)
        {
            _logger = logger;
            _featureSetup = featureSetup;
        }

        public override Task<VelocityResponse> GetVelocity(VelocityRequest request, ServerCallContext context)
        {
            var phoneRecord = _featureSetup.GetSourceData().GetData(request.PhoneNumber);
            
            return Task.FromResult(new VelocityResponse
            {
                Message = $"Hello {request.PhoneNumber}Items {phoneRecord.Result}"
            });
        }
    }
}
