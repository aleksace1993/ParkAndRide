using ParkAndRide.Common.CQRS;
using ParkAndRide.Common.RabbitMq.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ParkAndRide.Services.Rides.CQRS.Commands
{
    public class DeleteRide : ICommand
    {
        public Guid Id { get; set; }

 
        public DeleteRide(Guid id)
        {
            this.Id = id;
        }

        public IRejectedEvent Error(Exception e)
        {
            return new DeleteRideRejected(e.Message, "delete_ride_rejected");
        }

        public ISucceededEvent Success()
        {
            throw new NotImplementedException();
        }
    }
}
