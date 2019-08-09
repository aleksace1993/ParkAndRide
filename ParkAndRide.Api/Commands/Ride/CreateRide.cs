using ParkAndRide.Common.CQRS;
using ParkAndRide.Common.RabbitMq.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ParkAndRide.Api.Commands.Ride
{
    public class CreateRide : ICommand
    {
        public Guid Id { get; set; }
        public string CarType { get; set; }
        public int NumPassengers { get; set; }
        public string DriverName { get; set; }
        //public Driver Driver { get; set; }
        //public Location LocationFrom { get; set; }
        //public Location LocationTo { get; set; }
        //public DateTimeOffset DriveTime { get; set; }
        public CreateRide()
        {

        }
        //Todo: We dont need these here, figure out what to do
        public IRejectedEvent Error(Exception e)
        {
            throw new NotImplementedException();
        }

        public ISucceededEvent Success()
        {
            throw new NotImplementedException();
        }
    }
}
