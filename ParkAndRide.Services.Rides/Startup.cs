using System;
using System.ComponentModel;
using System.Reflection;
using Autofac;
using Autofac.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using ParkAndRide.Services.Rides.Domain;
using ParkAndRide.Common;
using ParkAndRide.Common.Mongo;
using ParkAndRide.Common.MVC;
using Swashbuckle.AspNetCore.Swagger;
using ParkAndRide.Common.CQRS;

namespace ParkAndRide.Services.Rides
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public Autofac.IContainer Container { get; private set; }
        // This method gets called by the runtime. Use this method to add services to the container.
        public IServiceProvider ConfigureServices(IServiceCollection services)
        {
            //services.AddCustomMvc();
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);

            //swagger
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new Info
                {
                    Version = "v1",
                    Title = "ApiGateway",
                });
            });

            //Autofac
            var builder = new ContainerBuilder();

            builder.RegisterAssemblyTypes(Assembly.GetExecutingAssembly())
               .AsImplementedInterfaces();
            builder.Populate(services);

            builder.AddMongo();
            builder.AddMongoRepository<Ride>("Rides");
            builder.AddCQRSDispatchers();

            Container = builder.Build();

            return new AutofacServiceProvider(Container);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, IMongoDbInitializer mongoDbInitializer)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            mongoDbInitializer.Initialize();
            app.UseMvc();

            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "My API V1");
            });
        }
    }
}
