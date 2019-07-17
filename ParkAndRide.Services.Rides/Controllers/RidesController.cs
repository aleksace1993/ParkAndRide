using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ParkAndRide.Common.CQRS;
using ParkAndRide.Common.Mongo;
using ParkAndRide.Services.Rides.CQRS.Queries;
using ParkAndRide.Services.Rides.Domain;
using ParkAndRide.Services.Rides.Dto;

namespace ParkAndRide.Services.Rides.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class RidesController : ControllerBase
    {
        private readonly IDispatcher _dispatcher;
        private readonly ICrudRepository<Ride> _ridesRepository;
        public RidesController(ICrudRepository<Ride> ridesRepository,
            IDispatcher dispatcher)
        {
            _dispatcher = dispatcher;
            _ridesRepository = ridesRepository;
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> Get([FromRoute] GetRide query)
        {
            return Ok(await _dispatcher.QueryAsync<RideDto>(query));
        }
        [HttpGet]
        public async Task<IActionResult> Get([FromQuery] BrowseRides query)
        {
            return Ok(await _dispatcher.QueryAsync<IEnumerable<RideDto>>(query));
        }
        [HttpPost]
        public IActionResult Post(Ride ride)
        {
            return Accepted(_ridesRepository.AddAsync(ride));
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(Guid id,Ride ride)
        {

            var existingRide = await _ridesRepository.GetAsync(r => r.Id == id);
            if(existingRide == null)
            {
                return NotFound();
            }
            //existingRide.Update(ride);
            return Accepted(_ridesRepository.UpdateAsync(existingRide));
        }
        //[HttpDelete("{id}")]
        //public IActionResult Delete([FromQuery]DeleteRide command)
        //{
        //    return Accepted(_dispatcher..AddAsync(ride));
        //}
    }
}