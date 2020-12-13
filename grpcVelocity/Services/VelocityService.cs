using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Amazon.DynamoDBv2;
using Amazon.DynamoDBv2.Model;
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
        public List<string> VariableConfiguration { get; set; }

        public VelocityService(ILogger<VelocityService> logger, IFeatureSetup featureSetup)
        {
            _logger = logger;
            _featureSetup = featureSetup;

            VariableConfiguration = _featureSetup.GetConfiguration().GetConfiguration("velocityList");
        }

        public override Task<VelocityResponse> GetVelocity(VelocityRequest request, ServerCallContext context)
        {
            var variableTransactions = _featureSetup.GetSourceData().GetData(request.PhoneNumber).Result;

            return Task.FromResult(new VelocityResponse
            {
               Message = $"Hello {request.PhoneNumber} Items: {variableTransactions} NumOfVar: {VariableConfiguration.Count}"
            });
        }
    }
}
