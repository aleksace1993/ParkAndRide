using ParkAndRide.Api.Dtos.Ride.RideDto;
using ParkAndRide.Api.Queries;
using RestEase;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ParkAndRide.Api.Services
{
    [SerializationMethods(Query = QuerySerializationMethod.Serialized)]
    public interface IRidesService
    {
        [AllowAnyStatusCode]
        [Get("rides/{id}")]
        Task<RideDto> GetAsync([Path] Guid id);
        
        [AllowAnyStatusCode]
        [Get("rides")]
        Task<IEnumerable<RideDto>> BrowseAsync([Query] BrowseRides query);
    }
}
