using ParkAndRide.Common.CQRS;
using ParkAndRide.Services.Rides.Dto;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ParkAndRide.Services.Rides.CQRS.Queries
{
    public class BrowseRides : IQuery
    {
        public string DriverName { get; set; }
        public string CarType { get; set; }
        public DateTime MinimalSearchDate { get; set; }
        public DateTime MaximalSearchDate { get; set; }
        public decimal MaximumCost { get; set; }
        public BrowseRides()
        {

        }
        //public Location location {get; set;}
        public bool Empty
        {
            //Todo: Fix this bug
            get
            {
                return DriverName == null &&
                    CarType == null &&
                    MaximumCost == default(decimal) &&
                    MinimalSearchDate == default(DateTime) &&
                    MaximalSearchDate == default(DateTime);
            }
        }
    }
}
