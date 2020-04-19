using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Unity;
using Unity.Microsoft.DependencyInjection;

namespace TechnicalChallenge.API2
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var container = new UnityContainer();
            CreateHostBuilder(args, container).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args, IUnityContainer container) =>
            Host.CreateDefaultBuilder(args)
                .UseUnityServiceProvider(container)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
    }
}
