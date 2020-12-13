using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Amazon.DynamoDBv2.DataModel;

namespace grpcVelocity.Model
{
    public class PhoneTransaction
    {
        public string PhoneHash { get; set; }
        public long EpochDatetime { get; set; }
    }
}
