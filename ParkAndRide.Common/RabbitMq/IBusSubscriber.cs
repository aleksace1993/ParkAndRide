using ParkAndRide.Common.CQRS;
using ParkAndRide.Common.RabbitMq.Messages;
using System;
using System.Collections.Generic;
using System.Text;

namespace ParkAndRide.Common.RabbitMq
{
    public interface IBusSubscriber
    {
        IBusSubscriber SubscribeCommand<TCommand>(string @namespace = null, string queueName = null) where TCommand : ICommand;
        IBusSubscriber SubscribeEvent<TEvent>(string @namespace = null, string queueName = null) where TEvent : IBusMessage;
    }
}
