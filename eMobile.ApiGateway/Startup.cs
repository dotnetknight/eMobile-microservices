using eMobile.Common.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Diagnostics.HealthChecks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Diagnostics.HealthChecks;
using Microsoft.Extensions.Hosting;
using Newtonsoft.Json;
using Ocelot.DependencyInjection;
using Ocelot.Middleware;

namespace eMobile.ApiGateway
{
    public class Startup
    {
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddOcelot();

            services.AddHealthChecks()
               .AddCheck<StartupHostedServiceHealthCheck>(
               "StartupHostedServiceHealthCheck",
               failureStatus: HealthStatus.Degraded,
               tags: new[] { "liveness" });

            services.AddHostedService<StartupHostedService>();
            services.AddSingleton<StartupHostedServiceHealthCheck>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHealthChecks("/health/liveness", new HealthCheckOptions()
            {
                Predicate = (check) => check.Tags.Contains("liveness"),

                ResponseWriter = async (context, report) =>
                {
                    context.Response.ContentType = "application/json";

                    await context.Response.WriteAsync(
                       JsonConvert.SerializeObject(
                           CreateHealthCheckResponse.Create(report)));
                }
            });

            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

            app.UseOcelot().Wait();
        }
    }
}
