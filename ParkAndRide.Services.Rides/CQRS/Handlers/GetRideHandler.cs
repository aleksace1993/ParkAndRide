using ParkAndRide.Common.CQRS;
using ParkAndRide.Common.Mongo;
using ParkAndRide.Services.Rides.CQRS.Queries;
using ParkAndRide.Services.Rides.Domain;
using ParkAndRide.Services.Rides.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ParkAndRide.Services.Rides.CQRS.Handlers
{
    public class GetRideHandler : IQueryHandler<GetRide, RideDto>
    {
        private ICrudRepository<Ride> _crudRepository;

        public GetRideHandler(ICrudRepository<Ride> crudRepository)
        {
            _crudRepository = crudRepository;
        }
        public async Task<RideDto> HandleAsync(GetRide query)
        {
            var ride = await _crudRepository.GetAsync(r=> r.Id == query.Id);

            if(ride == null)
            {
                return null;
            }

            return new RideDto(ride);
        }
    }
}
