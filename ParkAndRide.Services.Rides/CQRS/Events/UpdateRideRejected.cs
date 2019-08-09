using ParkAndRide.Common.RabbitMq.Messages;
using System;

namespace ParkAndRide.Services.Rides.CQRS.Commands
{
    public class UpdateRideRejected : IRejectedEvent
    {
        public Guid Id { get; }

        public string Reason { get; }

        public string Code { get; }

        public UpdateRideRejected(string reason, string code)
        {
            Reason = reason;
            Code = code;
        }
    }
}