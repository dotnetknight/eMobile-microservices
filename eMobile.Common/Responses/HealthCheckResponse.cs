using System;
using System.Collections.Generic;

namespace eMobile.Common.Responses
{
    public class HealthCheckResponse
    {
        public string Status { get; set; }
        public IEnumerable<HealthChecks> Checks { get; set; }
        public TimeSpan Duration { get; set; }
    }

    public class HealthChecks
    {
        public string Status { get; set; }
        public string Component { get; set; }
        public string Description { get; set; }
        public string ExceptionMessage { get; set; }
    }
}
