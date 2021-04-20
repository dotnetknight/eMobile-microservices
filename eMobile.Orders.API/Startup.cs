using Autofac;
using Autofac.Extensions.DependencyInjection;
using eMobile.IoC;
using eMobile.Orders.API.Filters;
using eMobile.Orders.Repository;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.Filters;
using System;
using System.IO;
using System.Reflection;
using Newtonsoft.Json;
using FluentValidation.AspNetCore;
using Common.Bus.RabbitMQ;
using eMobile.Orders.Service.Handlers.EventHandlers;
using eMobile.Orders.Models.Events;
using Common.Events;

namespace eMobile.Orders.API
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public IServiceProvider ConfigureServices(IServiceCollection services)
        {
            services.AddResponseCaching();

            services.AddControllers(options =>
            {
                options.ReturnHttpNotAcceptable = true;

                options.Filters.Add<ValidationFilter>();
                options.Filters.Add<ApiExceptionAttribute>();
                options.Filters.Add(new ProducesAttribute("application/json", "application/xml", "application/vnd.marvin.hateoas+json"));
                options.Filters.Add(new ConsumesAttribute("application/json", "application/xml"));
            })
              .AddNewtonsoftJson(options =>
              {
                  options.SerializerSettings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore;
                  options.SerializerSettings.NullValueHandling = NullValueHandling.Ignore;
              })
              .AddFluentValidation(fvc => fvc.RegisterValidatorsFromAssemblyContaining<Startup>())
              .AddXmlDataContractSerializerFormatters();

            services.AddSwaggerGen(c =>
            {
                c.ExampleFilters();

                var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
                var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
                c.IncludeXmlComments(xmlPath);

                c.SwaggerDoc("v1", new OpenApiInfo { Title = "eMobile.Orders.API", Version = "v1" });
            })
                .AddSwaggerExamplesFromAssemblyOf<Startup>();

            services.AddAutoMapper(typeof(Startup));

            services.AddDbContext<OrdersContext>(options => options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));

            services.AddTransient<PhoneCreatedEventHandler>();

            services.AddTransient<IEventHandler<PhoneCreatedEvent>, PhoneCreatedEventHandler>();

            var container = new ContainerBuilder();
            IoCService.RegisterServices(container, services);

            container.Populate(services);

            return new AutofacServiceProvider(container.Build());
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "eMobile.Orders.API v1"));
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

            ConfigureEventBus(app);
        }

        private static void ConfigureEventBus(IApplicationBuilder app)
        {
            var eventBus = app.ApplicationServices.GetRequiredService<IEventBus>();
            eventBus.Subscribe<PhoneCreatedEvent, PhoneCreatedEventHandler>();
        }
    }
}
