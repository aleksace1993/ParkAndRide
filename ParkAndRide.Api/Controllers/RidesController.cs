using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ParkAndRide.Api.Queries;
using ParkAndRide.Api.Services;

namespace ParkAndRide.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RidesController : ControllerBase
    {
        private IRidesService _ridesService;

        public RidesController(IRidesService ridesService)
        {
            _ridesService = ridesService;
        }

        [HttpGet]
        [AllowAnonymous]
        public async Task<IActionResult> Get([FromBody]BrowseRides query)
        {
           return Ok(await _ridesService.BrowseAsync(query));
        }
        
        [HttpGet("{id}")]
        [AllowAnonymous]
        public async Task<IActionResult> Get(Guid id)
        {
            return Ok(await _ridesService.GetAsync(id));
        }
        //[HttpPost]
        //public async Task<IActionResult> Post(CreateProduct command)
        //{ 
        //    await SendAsync(command.BindId(c => c.Id),
        //        resourceId: command.Id, resource: "products");
        //}
        //
        //[HttpPut("{id}")]
        //public async Task<IActionResult> Put(Guid id, UpdateProduct command)
        //{
        //    await SendAsync(command.Bind(c => c.Id, id),
        //       resourceId: command.Id, resource: "products");
        //}
        //
        //[HttpDelete("{id}")]
        //public async Task<IActionResult> Delete(Guid id)
        //{ 
        //    => await SendAsync(new DeleteProduct(id));
        //}

    }
}