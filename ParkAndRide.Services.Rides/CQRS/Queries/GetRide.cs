using ParkAndRide.Common.CQRS;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ParkAndRide.Services.Rides.CQRS.Queries
{
    public class GetRide : IQuery
    {
        public Guid Id { get; set; }
    }
}
