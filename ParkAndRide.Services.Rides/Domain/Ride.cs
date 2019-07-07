using ParkAndRide.Common.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ParkAndRide.Services.Rides.Domain
{
    public class Ride : BaseEntity
    {
        public Guid DriverId { get; private set; }
        public string CarType { get; private set; }
    }
}
