using ParkAndRide.Common.CQRS;
using ParkAndRide.Common.Mongo;
using ParkAndRide.Common.RabbitMq;
using ParkAndRide.Services.Rides.CQRS.Commands;
using ParkAndRide.Services.Rides.Domain;
using System;
using System.Threading.Tasks;

namespace ParkAndRide.Services.Rides.CQRS.Handlers
{
    public class DeleteRideHandler : ICommandHandler<DeleteRide>
    {
        private ICrudRepository<Ride> _crudRepository;
        private IBusPublisher _busPublisher;

        public DeleteRideHandler(ICrudRepository<Ride> crudRepository,
            IBusPublisher busPublisher)
        {
            _crudRepository = crudRepository;
            _busPublisher = busPublisher;
        }
        public async Task HandleAsync(DeleteRide command, ICorrelationContext context)
        {
            var ride = await _crudRepository.GetAsync(r => r.Id == command.Id);
            if(ride == null)
            {
                throw new Exception($"could not delete product. Product with id {command.Id} does not exist");
            }
            
            await _crudRepository.DeleteAsync(command.Id);
            //await _busPublisher.PublishAsync(new ProductDeleted(command.Id), context);
        }
    }
}
