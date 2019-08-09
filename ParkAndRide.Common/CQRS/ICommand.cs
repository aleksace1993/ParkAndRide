using ParkAndRide.Common.RabbitMq.Messages;
using System;

namespace ParkAndRide.Common.CQRS
{
    //Note: Every command should create an event upon success or error
    public interface ICommand : IBusMessage
    {
        IRejectedEvent Error(Exception e);
        ISucceededEvent Success();
    }
}
