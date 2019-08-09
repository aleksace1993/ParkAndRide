using Autofac;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;
using ParkAndRide.Common.CQRS;
using RawRabbit.Configuration;
using RawRabbit;
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;

namespace ParkAndRide.Common.RabbitMq
{
    public static class Extensions
    {
        public static IBusSubscriber UseRabbitMq(this IApplicationBuilder app)
        {
           return new BusSubscriber(app);
        }

        public static void AddRabbitMq(this ContainerBuilder builder)
        {
            //Register the options from appconfig into the DI container
            builder.Register(context => {
                var config = context.Resolve<IConfiguration>();

                var rabbitMqOptions = new RabbitMqOptions();
                config.GetSection("rabbitMq").Bind(rabbitMqOptions);

                return rabbitMqOptions;
            }).SingleInstance();

            builder.Register(context=> {
                var config = context.Resolve<IConfiguration>();
                var rawRabbitOptions = new RawRabbitConfiguration();
                config.GetSection("rabbitMq").Bind(rawRabbitOptions);

                return rawRabbitOptions;
            }).SingleInstance();

            //Note:Obtain the service assembly
            var assembly = Assembly.GetCallingAssembly();

            builder.RegisterAssemblyTypes(assembly).AsClosedTypesOf(typeof(ICommandHandler<>)).InstancePerDependency();
            //builder.RegisterAssemblyTypes(assembly).AsClosedTypesOf(typeof(IEventHandler<>)).InstancePerDependency();
            // builder.RegisterType<MessageHandler>().As<IMessageHandler>().InstancePerDependency();
            builder.RegisterType<BusPublisher>().As<IBusPublisher>().InstancePerDependency();;
            // builder.RegisterInstance(ParkAndRideTracer).As<ITracer>().SingleInstance().PreserveExistingDefaults();


            builder.Register<IIntanceFactory>(context =>
            {
                var options = context.Resolve<RabbitMqOptions>();
                var configuration = context.Resolve<RawRabbitConfiguration>();
                //  var tracer = context.Resolve<ITracer>();
                return RawRabbitFactory<InstanceFactory>.CreateInstanceFactory(new RawRabbitOptions
                {
                    DependencyInjection = ioc =>
                    {
                        ioc.AddSingleton(options);
                        ioc.AddSingleton(configuration);
                        // ioc.AddSingleton(tracer);
                    },
                    Plugins = p => p
                        .UseAttributeRouting()
                        .UseRetryLater()
                        .UpdateRetryInfo()
                        .UseMessageContext<CorrelationContext>()
                        .UseContextForwarding()
                    //.UseJaeger(tracer)
                });
            }).SingleInstance();
            //Create the instance factory and instantiate it right away???
            builder.Register(context => context.Resolve<IInstanceFactory>().Create());
        }
    }
}
