using ParkAndRide.Common.CQRS;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ParkAndRide.Services.Rides.CQRS.Commands
{
    public class DeleteRide : ICommand
    {
        public Guid Id { get; set; }

 
        public DeleteRide(Guid id)
        {
            this.Id = id;
        }
    }
}
