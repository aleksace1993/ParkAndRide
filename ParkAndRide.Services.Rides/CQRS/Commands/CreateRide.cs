using ParkAndRide.Common.CQRS;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ParkAndRide.Services.Rides.CQRS.Commands
{
    public class CreateRide :ICommand
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
    }
}
