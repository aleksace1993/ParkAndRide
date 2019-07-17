using ParkAndRide.Common.CQRS;
using ParkAndRide.Services.Rides.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ParkAndRide.Services.Rides.CQRS.Queries
{
    public class BrowseRides : IQuery
    {
        public string DriverName { get; set; }
        public decimal MinimalCost { get; set; }
        public decimal MaximalCost { get; set; }
        public string CarType { get; set; }
        public DateTime MinimalSearchDate { get; set; }
        public DateTime MaximalSearchDate { get; set; }

        //public Location location {get; set;}
        public bool Empty
        {
            get
            {
                return DriverName != null ||
                    MinimalCost != default(decimal) ||
                    MaximalCost != default(decimal) ||
                    MinimalSearchDate != default(DateTime) ||
                    MaximalSearchDate != default(DateTime);
            }
        }
    }
}
