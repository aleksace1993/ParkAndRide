using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Logging;
using ParkAndRide.Common.CQRS;
using ParkAndRide.Common.RabbitMq.Messages;
using RawRabbit;
using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Extensions.DependencyInjection;
using System.Threading.Tasks;
using RawRabbit.Context;
using RawRabbit.Configuration.Subscribe;
using System.Reflection;

namespace ParkAndRide.Common.RabbitMq
{
    public class BusSubscriber : IBusSubscriber
    {
        private IBusClient _busClient;
        private ILogger _logger;
        private IServiceProvider _serviceProvider;
        private string _defaultNamespace;

        public BusSubscriber(IApplicationBuilder app)
        {
            _serviceProvider = app.ApplicationServices.GetService<IServiceProvider>();
            _logger = _serviceProvider.GetService<ILogger>();
            _busClient = _serviceProvider.GetService<IBusClient>();

            var options = _serviceProvider.GetService<RabbitMqOptions>();
            _defaultNamespace = options.Namespace;
        }
        public IBusSubscriber SubscribeCommand<TCommand>(string @namespace = null, string queueName = null) where TCommand : ICommand
        { 
            Func<TCommand,MessageContext,Task> subscribeMethod = (async (command, msgContext) => {
                var commandHandler = _serviceProvider.GetService<ICommandHandler<TCommand>>();

                await TryHandleAsync(command, msgContext, commandHandler);
            });

            //Configure the subscription queue name
            Action<ISubscriptionConfigurationBuilder> configuration = (cfg) => {
                cfg.WithQueue(q =>
                {
                    q.WithName(GetQueueName<TCommand>(@namespace, queueName));
                });

            };


            _busClient.SubscribeAsync<TCommand>(subscribeMethod, configuration);

            return this;
        }
        public IBusSubscriber SubscribeEvent<TEvent>(string @namespace = null, string queueName = null) where TEvent : IBusMessage
        {
            throw new NotImplementedException();
        }

        private Task TryHandleAsync<TCommand>(TCommand command, MessageContext msgContext, ICommandHandler<TCommand> commandHandler) where TCommand : ICommand
        {
            throw new NotImplementedException();
        }

        private string GetQueueName<T>(string @namespace, string queueName) 
        {
            if(string.IsNullOrWhiteSpace(@namespace))
            {
                @namespace = _defaultNamespace;
            }
            //add a dot to the namespace
            string separatedNamespace = string.IsNullOrWhiteSpace(@namespace) ? string.Empty : $"{@namespace}.";

            string queueNameResult = "";
            if (string.IsNullOrWhiteSpace(queueName))
            {
                //The queue name starts with the assembly name parkAndride.products/products.creatproducts_
                queueNameResult = (Assembly.GetEntryAssembly().GetName().Name + "/" + separatedNamespace + typeof(T).Name + "_").ToLowerInvariant();
            }
            else
            {
                //the queue name starts with the strongly typed name 
                queueNameResult = (queueName + "/" + separatedNamespace + typeof(T).Name + "_").ToLowerInvariant();
            }
            return queueNameResult;
         }
        



    }
}
