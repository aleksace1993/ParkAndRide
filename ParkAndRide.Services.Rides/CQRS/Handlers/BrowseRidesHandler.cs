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
    public class BrowseRidesHandler : IQueryHandler<BrowseRides, IEnumerable<RideDto>>
    {
        private ICrudRepository<Ride> _crudRepository;

        public BrowseRidesHandler(ICrudRepository<Ride> crudRepository)
        {
            _crudRepository = crudRepository;
        }

        public async Task<IEnumerable<RideDto>> HandleAsync(BrowseRides query)
        {

            if(!query.Empty)
            {
                //Todo: Expand the query to get all the filtered rides
               IEnumerable<Ride> searchedRides = await _crudRepository.FindAllAsync(r => r.CarType == query.CarType);
                return RideDto.FromRides(searchedRides);
            }
            IEnumerable<Ride> allRides = await _crudRepository.FindAllAsync(r => true);
            return RideDto.FromRides(allRides);
        }
    }
}
