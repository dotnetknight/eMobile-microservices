using Microsoft.Extensions.Hosting;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace eMobile.Common.Services
{
    public class StartupHostedService : IHostedService, IDisposable
    {
        private readonly int delaySeconds = 10;
        private readonly StartupHostedServiceHealthCheck startupHostedServiceHealthCheck;

        public StartupHostedService(StartupHostedServiceHealthCheck startupHostedServiceHealthCheck)
        {
            this.startupHostedServiceHealthCheck = startupHostedServiceHealthCheck;
        }

        public Task StartAsync(CancellationToken cancellationToken)
        {
            Task.Run(async () =>
            {
                await Task.Delay(delaySeconds * 1000);

                startupHostedServiceHealthCheck.StartupTaskCompleted = true;
            });

            return Task.CompletedTask;
        }

        public Task StopAsync(CancellationToken cancellationToken)
        {
            return Task.CompletedTask;
        }

        public void Dispose()
        {
        }
    }
}
