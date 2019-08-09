using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using ParkAndRide.Common.CQRS;
using ParkAndRide.Common.RabbitMq.Messages;

namespace ParkAndRide.Common.RabbitMq
{
    public class BusPublisher : IBusPublisher
    {
        public Task PublishAsync<TEvent>(TEvent @event, ICorrelationContext context) where TEvent : IBusMessage
        {
            throw new NotImplementedException();
        }

        public Task SendAsync<TCommand>(TCommand command, ICorrelationContext context) where TCommand : ICommand
        {
            throw new NotImplementedException();
        }
    }
}
