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

        public async Task<TResult> QueryAsync<TQuery,TResult>(TQuery query) where TQuery : IQuery
        {

            //Different sollution without the TQuery generic parameter
            //public async Task<TResult> QueryAsync<TResult>(IQuery query)
            // var handlerType = typeof(IQueryHandler<,>)
            //     .MakeGenericType(query.GetType(), typeof(TResult));
            //
            // dynamic handler = _componentContext.Resolve(handlerType);
            //
            // return await handler.HandleAsync((dynamic)query);

            //Note: Easier solution with both the input type and the Result type supplied, resolved successfully at runtime
            var queryHandler = _componentContext.Resolve<IQueryHandler<TQuery, TResult>>();
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