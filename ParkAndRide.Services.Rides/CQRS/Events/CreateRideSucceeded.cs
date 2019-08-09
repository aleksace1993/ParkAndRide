using ParkAndRide.Common.RabbitMq.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ParkAndRide.Services.Rides.CQRS.Events
{
    public class CreateRideSucceeded : ISucceededEvent
    {
    }
}
