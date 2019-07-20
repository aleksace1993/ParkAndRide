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
            IEnumerable<Ride> allRides = await _crudRepository.FindAllAsync(r => true);
            if (!query.Empty)
            {
                if(query.MaximalSearchDate != default(DateTime) && query.MinimalSearchDate != default(DateTime))
                {
                    allRides = allRides.Where(r =>r.rideDate >= query.MinimalSearchDate && 
                                                  r.rideDate <= query.MaximalSearchDate);
                }
                if(query.MaximumCost != default(decimal))
                {
                    allRides = allRides.Where(r => r.Cost < query.MaximumCost);
                }
                if(query.DriverName != null)
                {
                    allRides = allRides.Where(r => r.DriverName == query.DriverName);
                }
                if (query.CarType != null)
                {
                    allRides = allRides.Where(r => r.CarType == query.CarType);
                }
                //if (query.LocationName != null)
                //{
                //    allRides = allRides.Where(r => r.Location.Name == query.LocationName);
                //}
             
            }
            //query is empty retrieve all rides
            
            return RideDto.FromRides(allRides);
        }
    }
}
