using ParkAndRide.Common.CQRS;
using ParkAndRide.Common.RabbitMq.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ParkAndRide.Services.Rides.CQRS.Commands
{
    public class UpdateRide : ICommand
    {
        public Guid Id { get; set; }
        public string CarType { get; set; }
        public int NumPassengers { get; set; }
        public string DriverName { get; set; }
        public DateTime RideDate { get; set; }

        //public Driver Driver { get; set; }
        //public Location LocationFrom { get; set; }
        //public Location LocationTo { get; set; }
        //public DateTimeOffset DriveTime { get; set; }
        public UpdateRide()
        {

        }

        public IRejectedEvent Error(Exception e)
        {
            return new UpdateRideRejected(e.Message, "update_ride_rejected");
        }

        public ISucceededEvent Success()
        {
            throw new NotImplementedException();
        }
    }
}
