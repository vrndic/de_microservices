using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DataEngineering.Microservices.Features;
using Grpc.Core;
using Microsoft.Extensions.Logging;

namespace grpcVelocity
{
    public class VelocityService : Velocity.VelocityBase
    {
        private readonly ILogger<VelocityService> _logger;
        public VelocityService(ILogger<VelocityService> logger)
        {
            _logger = logger;
        }

        public override Task<VelocityResponse> GetVelocity(VelocityRequest request, ServerCallContext context)
        {
            return Task.FromResult(new VelocityResponse
            {
                Message = "Hello " + request.PhoneNumber
            });
        }
    }
}
