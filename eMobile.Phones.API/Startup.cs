using Autofac;
using Autofac.Extensions.DependencyInjection;
using eMobile.IoC;
using eMobile.Phones.API.Filters;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using Newtonsoft.Json;
using Swashbuckle.AspNetCore.Filters;
using System;
using System.IO;
using System.Reflection;
using FluentValidation.AspNetCore;
using Microsoft.EntityFrameworkCore;
using eMobile.Phones.Repository;
using Microsoft.Extensions.Diagnostics.HealthChecks;
using Microsoft.AspNetCore.Diagnostics.HealthChecks;
using Microsoft.AspNetCore.Http;
using eMobile.Common.Services;

namespace eMobile.Phones.API
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

                c.SwaggerDoc("v1", new OpenApiInfo { Title = "eMobile.Phones.API", Version = "v1" });
            })
                .AddSwaggerExamplesFromAssemblyOf<Startup>();

            services.AddAutoMapper(typeof(Startup));

            services.AddDbContext<PhonesContext>(options => options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")))
                .AddHealthChecks()
                .AddDbContextCheck<PhonesContext>(
                name: "PhonesContext",
                failureStatus: HealthStatus.Degraded,
                tags: new[] { "readiness" });

            services.AddHealthChecks()
                .AddCheck<StartupHostedServiceHealthCheck>(
                "StartupHostedServiceHealthCheck",
                failureStatus: HealthStatus.Degraded,
                tags: new[] { "liveness" });

            services.AddHostedService<StartupHostedService>();
            services.AddSingleton<StartupHostedServiceHealthCheck>();

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
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "eMobile.Phones.API v1"));
            }

            app.UseHealthChecks("/health/readiness", new HealthCheckOptions()
            {
                Predicate = (check) => check.Tags.Contains("readiness"),

                ResponseWriter = async (context, report) =>
                {
                    context.Response.ContentType = "application/json";

                    await context.Response.WriteAsync(
                      JsonConvert.SerializeObject(
                          CreateHealthCheckResponse.Create(report)));
                }
            });

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

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
