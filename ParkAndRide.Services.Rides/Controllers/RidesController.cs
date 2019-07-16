using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ParkAndRide.Common.Mongo;
using ParkAndRide.Services.Rides.Domain;

namespace ParkAndRide.Services.Rides.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class RidesController : ControllerBase
    {
        private readonly ICrudRepository<Ride> _ridesRepository;
        public RidesController(ICrudRepository<Ride> ridesRepository)
        {
            _ridesRepository = ridesRepository;
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(Guid id)
        {
            return Ok(await _ridesRepository.GetAsync(r => r.Id == id));
        }
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            return Ok(await _ridesRepository.FindAllAsync(r => true));
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
            existingRide.Update(ride);
            return Accepted(_ridesRepository.UpdateAsync(existingRide));
        }
    }
}