using ParkAndRide.Api.Models.Rides;
using ParkAndRide.Api.Queries;
using RestEase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ParkAndRide.Api.Services
{
    public interface IRidesService
    {
        [AllowAnyStatusCode]
        [Get("rides/{id}")]
        Task<Ride> GetAsync([Path] Guid id);
        
        [AllowAnyStatusCode]
        [Get("rides")]
        Task<IEnumerable<Ride>> BrowseAsync([Query] BrowseRides query);
    }
}
