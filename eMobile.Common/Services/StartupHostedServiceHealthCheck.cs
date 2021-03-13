using Microsoft.Extensions.Diagnostics.HealthChecks;
using System.Threading;
using System.Threading.Tasks;

namespace eMobile.Common.Services
{
    public class StartupHostedServiceHealthCheck : IHealthCheck
    {
        private volatile bool startupTaskCompleted = false;

        public string Name => "slow_dependency_check";

        public bool StartupTaskCompleted
        {
            get => startupTaskCompleted;
            set => startupTaskCompleted = value;
        }

        public Task<HealthCheckResult> CheckHealthAsync(HealthCheckContext context, CancellationToken cancellationToken = default)
        {
            if (StartupTaskCompleted)
            {
                return Task.FromResult(
                    HealthCheckResult.Healthy("The startup task is finished."));
            }

            return Task.FromResult(
                HealthCheckResult.Unhealthy("The startup task is still running."));
        }
    }
}
