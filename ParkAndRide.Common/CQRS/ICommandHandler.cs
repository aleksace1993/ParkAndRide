using ParkAndRide.Common.RabbitMq;
using ParkAndRide.Common.Types;
using System.Threading.Tasks;

namespace ParkAndRide.Common.CQRS
{
    public interface ICommandHandler<TCommand> where TCommand : ICommand
    {
        Task HandleAsync(TCommand command, ICorrelationContext context);
    }
}
