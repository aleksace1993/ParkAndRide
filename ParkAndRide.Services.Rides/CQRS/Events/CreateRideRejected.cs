using ParkAndRide.Common.RabbitMq.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ParkAndRide.Services.Rides.CQRS.Events
{
    public class CreateRideRejected : IRejectedEvent
    {
        public Guid Id { get; }

        public string Reason { get; }

        public string Code { get; }

        public CreateRideRejected(string reason, string code)
        {
            Reason = reason;
            Code = code;
        }
    }
}
