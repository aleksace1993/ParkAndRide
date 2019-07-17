using ParkAndRide.Common.CQRS;
using ParkAndRide.Common.Mongo;
using ParkAndRide.Common.RabbitMq;
using ParkAndRide.Services.Rides.CQRS.Commands;
using ParkAndRide.Services.Rides.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ParkAndRide.Services.Rides.CQRS.Handlers
{
    public class CreateRideHandler : ICommandHandler<CreateRide>
    {
        private ICrudRepository<Ride> _crudRepository;
        private IBusPublisher _busPublisher;

        public CreateRideHandler(ICrudRepository<Ride> crudRepository,
            IBusPublisher busPublisher)
        {
            _crudRepository = crudRepository;
            _busPublisher = busPublisher;
        }
        public async Task HandleAsync(CreateRide command, ICorrelationContext context)
        {
            //Todo: Check if the same driver has rides scheduled during that time
            var ride = new Ride(command);
            await _crudRepository.AddAsync(ride);
           
           // await _busPublisher.PublishAsync(new ProductCreated(command.Id, command.Name,
           //     command.Description, command.Vendor, command.Price, command.Quantity), context);
        }
    }
}
