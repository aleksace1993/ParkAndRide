using Autofac;
using Microsoft.Extensions.Configuration;
using MongoDB.Driver;
using ParkAndRide.Common.Types;
using System;
using System.Collections.Generic;
using System.Text;

namespace ParkAndRide.Common.Mongo
{
    public static class Extensions
    {
        public static void AddMongo(this ContainerBuilder builder)
        {
            builder.Register(context =>
            {
                var configuration = context.Resolve<IConfiguration>();
                MongoDbOptions options = new MongoDbOptions();

                //Bind the class to the section in config
                configuration.GetSection("mongo").Bind(options);
                return options;
            }).SingleInstance();

            builder.Register(context =>
            {
                var options = context.Resolve<MongoDbOptions>();

                return new MongoClient(options.ConnectionString);
            }).SingleInstance();

            builder.Register(context =>
            {
                var options = context.Resolve<MongoDbOptions>();
                var client = context.Resolve<MongoClient>();
                return client.GetDatabase(options.Database);

            }).InstancePerLifetimeScope();

            builder.RegisterType<MongoDbInitializer>()
                .As<IMongoDbInitializer>()
                .InstancePerLifetimeScope();

            builder.RegisterType<MongoDbSeeder>()
                .As<IMongoDbSeeder>()
                .InstancePerLifetimeScope();
        }


        public static void AddMongoRepository<TEntity>(this ContainerBuilder builder, string dbCollectionName) 
            where TEntity : IEntity
        {
            builder.Register(ctx => new MongoRepository<TEntity>(ctx.Resolve<IMongoDatabase>(), dbCollectionName))
                .As<ICrudRepository<TEntity>>()
                .InstancePerLifetimeScope();
        }
    }
}
