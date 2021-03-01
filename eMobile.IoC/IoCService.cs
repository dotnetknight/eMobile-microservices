using Autofac;
using Common.Bus.CQRS;
using Common.Bus.RabbitMQ;
using Microsoft.Extensions.DependencyInjection;

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

            services.AddTransient<ICommandBusAsync, CommandBusAsync>();
        }
    }
}
