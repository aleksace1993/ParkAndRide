﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ParkAndRide.Api.Queries
{
    public class BrowseRides
    {
        public string DriverName { get; set; }
        public string CarType { get; set; }
        public DateTime MinimalSearchDate { get; set; }
        public DateTime MaximalSearchDate { get; set; }
        public decimal MaximumCost { get; set; }
    }
}
