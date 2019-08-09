using System;
using System.Collections.Generic;
using System.Text;

namespace ParkAndRide.Common.RabbitMq.Messages
{
    public interface IRejectedEvent : IBusMessage
    {
        string Reason { get; }
        string Code { get;  }
    }
}
