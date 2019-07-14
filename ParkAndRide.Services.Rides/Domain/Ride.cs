using ParkAndRide.Common.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ParkAndRide.Services.Rides.Domain
{
    public class Ride : BaseEntity
    {
        public Guid RideId { get; private set; }
        public string CarType { get; private set; }
        public int NumPassengers { get; private set; }
        //public Driver Driver { get; private set; }
        //public Location LocationFrom { get; private set; }
        //public Location LocationTo { get; private set; }
        //public DateTimeOffset DriveTime { get; private set; }
        
    }
}
