using ParkAndRide.Services.Rides.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ParkAndRide.Services.Rides.Dto
{
    public class RideDto
    {
        public Guid Id { get; set; }
        public string CarType { get; set; }
        public int NumPassengers { get; set; }
        public decimal Cost { get; set; }
        public string DriverName { get; set; }
        public DateTime RideDate { get; set; }
        //public Driver Driver { get; private set; }
        //public Location LocationFrom { get; private set; }
        //public Location LocationTo { get; private set; }
        //public DateTimeOffset DriveTime { get; private set; }

        public RideDto(Ride ride)
        {
            this.Id = ride.Id;
            this.CarType = ride.CarType;
            this.NumPassengers = ride.NumPassengers;
            this.Cost = ride.Cost;
            this.DriverName = ride.DriverName;
            this.RideDate = ride.rideDate;
        }
        public static IEnumerable<RideDto> FromRides(IEnumerable<Ride> rides)
        {
            List<RideDto> list = new List<RideDto>();
            foreach(var ride in rides)
            {
                list.Add(new RideDto(ride));               
            }
            return list;
        }
    }
}
