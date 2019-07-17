using Autofac;

namespace ParkAndRide.Common.CQRS
{
    public static class Extensions
    {
        public static void AddCQRSDispatchers(this ContainerBuilder builder)
        {
            builder.RegisterType<Dispatcher>().As<IDispatcher>();
        }
    }
}
