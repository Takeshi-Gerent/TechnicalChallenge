using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Unity;
using Unity.Lifetime;
using Microsoft.OpenApi.Models;
using Microsoft.Extensions.PlatformAbstractions;
using System.IO;
using TechnicalChallenge.Framework.Factories;
using TechnicalChallenge.API2.Core.Services;
using TechnicalChallenge.API2.Service;

namespace TechnicalChallenge.API2
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureContainer(IUnityContainer container)
        {
            var serviceFactory = new ServiceFactory(container);
            container.RegisterInstance<IServiceFactory>(serviceFactory);

            container.RegisterType<ICalculaJurosService, CalculaJurosService>(new ContainerControlledLifetimeManager());
            container.RegisterType<IShowMeTheCodeService, ShowMeTheCodeService>(new ContainerControlledLifetimeManager());
        }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            var url = string.Format("http://{0}", Environment.GetEnvironmentVariable("API1_URL"));//Configuration["Api:UrlApi1"];
            services.AddControllers();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1.0",
                    new OpenApiInfo
                    {
                        Title = "Desafio técnico - Softplan",
                        Description = "Api2 - Calculo de juros compostos",
                        Version = "1.0",
                        Contact = new OpenApiContact { Name = "Marcelo Takeshi Inoue Gerent", Email = "marcelo.t.gerent@gmail.com" }
                    });
                var appPath = PlatformServices.Default.Application.ApplicationBasePath;
                string appName = PlatformServices.Default.Application.ApplicationName;
                string xmlDocPath = Path.Combine(appPath, $"{appName}.xml");

                c.IncludeXmlComments(xmlDocPath);
            });

            services.AddHttpClient("api", config =>
            {
                config.BaseAddress = new Uri(url);
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseSwagger();

            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1.0/swagger.json", "API 1");
                c.RoutePrefix = string.Empty;
            });

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
