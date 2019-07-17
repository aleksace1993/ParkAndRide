using System.Threading.Tasks;
using Autofac;
using ParkAndRide.Common.RabbitMq;

namespace ParkAndRide.Common.CQRS
{
    public class Dispatcher : IDispatcher
    {
        private IComponentContext _componentContext;

        public Dispatcher(IComponentContext componentContext)
        {
            _componentContext = componentContext;
        }

        public async Task<TResult> QueryAsync<TResult>(IQuery query)
        {
            //TODO: Figure this out
            // var handlerType = typeof(IQueryHandler<,>)
            //     .MakeGenericType(query.GetType(), typeof(TResult));
            //
            // dynamic handler = _componentContext.Resolve(handlerType);
            //
            // return await handler.HandleAsync((dynamic)query);

            var queryHandler = _componentContext.Resolve<IQueryHandler<IQuery, TResult>>();
            return await queryHandler.HandleAsync(query);
        }

        public async Task SendAsync<T>(T command) where T : ICommand
        {
            //Find the specific command handler from the IOC container for the command
            var commandHandler = _componentContext.Resolve<ICommandHandler<T>>();
            await commandHandler.HandleAsync(command, new CorrelationContext());
        }
    }
}