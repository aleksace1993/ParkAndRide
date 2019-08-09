using ParkAndRide.Common.RabbitMq.Messages;
using System;

namespace ParkAndRide.Services.Rides.CQRS.Commands
{
    internal class DeleteRideRejected : IRejectedEvent
    {
        public Guid Id { get; }

        public string Reason { get; }

        public string Code { get; }

        public DeleteRideRejected(string reason, string code)
        {
            this.Reason = reason;
            this.Code = code;
        }
    }
}