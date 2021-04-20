using Autofac;
using Common.Bus.CQRS;
using Common.Bus.RabbitMQ;
using eMobile.Common.Bus.CQRS;
using eMobile.Phones.Service.Handlers.CommandHandlers;
using Microsoft.Extensions.DependencyInjection;
using Autofac.Extras.DynamicProxy;
using eMobile.Phones.Service.Helpers;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using eMobile.Phones.Service.Handlers.QueryHandlers;

namespace eMobile.IoC
{
    public class IoCService
    {
        public static void RegisterServices(ContainerBuilder builder, IServiceCollection services)
        {
            services.AddSingleton<IEventBus, RabbitMQBus>(sp =>
            {
                var scopeFactory = sp.GetRequiredService<IServiceScopeFactory>();
                return new RabbitMQBus(scopeFactory);
            });

            services.AddSingleton<IActionContextAccessor, ActionContextAccessor>();

            services.AddSingleton(typeof(HATEOASLinksService), typeof(HATEOASLinksService));
            services.AddSingleton(typeof(MediaTypeCheckService), typeof(MediaTypeCheckService));

            services.AddTransient(typeof(Phones.Repository.IRepository<>), typeof(Phones.Repository.Repository<>));
            services.AddTransient(typeof(Orders.Repository.IRepository<>), typeof(Orders.Repository.Repository<>));

            services.AddTransient<ICommandBusAsync, CommandBusAsync>();
            services.AddTransient<IQueryBusAsync, QueryBusAsync>();

            builder.RegisterAssemblyTypes(typeof(CreatePhoneCommandHandler).Assembly)
                .AsClosedTypesOf(typeof(ICommandHandlerAsync<,>))
                .EnableClassInterceptors();

            builder.RegisterAssemblyTypes(typeof(UpdatePhoneCommandHandler).Assembly)
                .AsClosedTypesOf(typeof(ICommandHandlerAsync<>))
                .EnableClassInterceptors();

            builder.RegisterAssemblyTypes(typeof(PhoneQueryHandler).Assembly)
                .AsClosedTypesOf(typeof(IQueryHandlerAsync<,>))
                .EnableClassInterceptors();

        }
    }
}
