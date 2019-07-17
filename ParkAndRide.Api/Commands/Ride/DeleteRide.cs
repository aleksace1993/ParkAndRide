using Newtonsoft.Json;
using ParkAndRide.Common.CQRS;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ParkAndRide.Api.Commands.Ride
{
    public class DeleteRide : ICommand
    {
        public Guid Id { get; set; }

        [JsonConstructor]
        public DeleteRide(Guid id)
        {
            this.Id = id;
        }
    }
}
