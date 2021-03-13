using eMobile.Common.Responses;
using Microsoft.Extensions.Diagnostics.HealthChecks;
using System.Linq;

namespace eMobile.Common.Services
{
    public static class CreateHealthCheckResponse
    {
        public static HealthCheckResponse Create(HealthReport report)
        {
            return new HealthCheckResponse
            {
                Status = report.Status.ToString(),
                Checks = report.Entries.Select(entry =>
                    new HealthChecks
                    {
                        Component = entry.Key,
                        Status = entry.Value.Status.ToString(),
                        ExceptionMessage = entry.Value.Exception?.Message,
                        Description = entry.Value.Description != entry.Value.Exception?.Message ? entry.Value.Description : null
                    }),
                Duration = report.TotalDuration
            };
        }
    }
}
