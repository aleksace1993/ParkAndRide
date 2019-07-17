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
    public class UpdateRideHandler : ICommandHandler<UpdateRide>
    {
        private ICrudRepository<Ride> _crudRepository;
        private IBusPublisher _busPublisher;

        public UpdateRideHandler(ICrudRepository<Ride> crudRepository, 
            IBusPublisher busPublisher)
        {
            _crudRepository = crudRepository;
            _busPublisher = busPublisher;
        }

        public async Task HandleAsync(UpdateRide command, ICorrelationContext context)
        {
            var ride = await _crudRepository.GetAsync(r => r.Id == command.Id);
            if (ride == null)
            {
                throw new Exception($"could not edit product. Product with id {command.Id} does not exist");
            }

            ride.Update(command);

            await _crudRepository.UpdateAsync(ride);
            //await _busPublisher.PublishAsync(new ProductUpdated(command.Id, command.Name,
            //   command.Description, command.Vendor, command.Price, command.Quantity), context);
        }
    }
}
