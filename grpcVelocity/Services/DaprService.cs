using System.Threading.Tasks;
using DataEngineering.Microservices;
using DataEngineering.Microservices.Features;
using Google.Protobuf.WellKnownTypes;
using Grpc.Core;
using Microsoft.Extensions.Logging;
using static DataEngineering.Microservices.InvokeResponse;

namespace grpcVelocity
{
    public class DaprService : DataEngineering.Microservices.Dapr.DaprBase
    {
        private readonly ILogger<VelocityService> _logger;
        private readonly VelocityService _velocityService;
        public DaprService(ILogger<VelocityService> logger, VelocityService velocityService)
        {
            _logger = logger;
            _velocityService = velocityService;
        }

        public override Task<InvokeResponse> InvokeService(InvokeServiceRequest request, ServerCallContext context)
        {
            var response = new Any();
            switch (request.Message.Method)
            {
                case "GetVelocity":
                    var inputString = request.Message.Data.Value.ToStringUtf8();
                    var velocityRequest = new VelocityRequest { PhoneNumber = inputString };
                    var velocityResponse = _velocityService.GetVelocity(velocityRequest, context).Result;

                    var msg = new VelocityResponse { Message = velocityResponse.Message, Response = { velocityResponse.Response } };
                    response = Any.Pack(msg);
                    break;
            }

            return Task.FromResult(new InvokeResponse
            {
                Data = response
            });
        }
    }
}
