using ParkAndRide.Common.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ParkAndRide.Services.Rides.Domain
{
    public class Ride : BaseEntity
    {
        public string CarType { get;  set; }
        public int NumPassengers { get;  set; }
        //public Driver Driver { get; private set; }
        //public Location LocationFrom { get; private set; }
        //public Location LocationTo { get; private set; }
        //public DateTimeOffset DriveTime { get; private set; }
        public void Update(Ride newRide)
        {
            //Todo: figure out hwo to update things that are not Set.
            this.CarType = newRide.CarType;
            this.NumPassengers = newRide.NumPassengers;
        }
    }
}
