using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ParkAndRide.Api.Dtos.Ride
{
    public class RideDto
    {
        public Guid Id { get; set; }
        public string CarType { get; set; }
        public int NumPassengers { get; set; }
        public decimal Cost { get; set; }
        public string DriverName { get; set; }
        public DateTime RideDate { get; set; }
        public RideDto()
        {

        }
    }
}
