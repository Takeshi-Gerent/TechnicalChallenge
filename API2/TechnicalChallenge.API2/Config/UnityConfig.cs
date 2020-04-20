using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using TechnicalChallenge.API2.Core.Services;
using TechnicalChallenge.API2.Service;
using TechnicalChallenge.Framework.Factories;
using Unity;
using Unity.Lifetime;

namespace TechnicalChallenge.API2.Config
{
    public class UnityConfig
    {
        private static Lazy<IUnityContainer> container = new Lazy<IUnityContainer>(() =>
        {
            var container = new UnityContainer();
            RegisterTypes(container);
            return container;
        });

        /// <summary>
        /// Gets the configured Unity container.
        /// </summary>
        public static IUnityContainer GetConfiguredContainer()
        {
            return container.Value;
        }

        public static void RegisterTypes(IUnityContainer container)
        {
            var url = $"http://{Environment.GetEnvironmentVariable("API1_URL")}";

            var serviceFactory = new ServiceFactory(container);
            container.RegisterInstance<IServiceFactory>(serviceFactory);

            container.RegisterType<ICalculaJurosService, CalculaJurosService>(new ContainerControlledLifetimeManager());
            container.RegisterType<IShowMeTheCodeService, ShowMeTheCodeService>(new ContainerControlledLifetimeManager());

            container.RegisterFactory<HttpClient>("api1", factory => new HttpClient { BaseAddress = new Uri(url) });     
        }

    }
}
