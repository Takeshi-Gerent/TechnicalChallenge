using TechnicalChallenge.Framework.Service;
using Unity;

namespace TechnicalChallenge.Framework.Factories
{
    public interface IServiceFactory
    { }

    public class ServiceFactory : IServiceFactory
    {
        protected readonly IUnityContainer _container;

        public ServiceFactory(IUnityContainer container)
        {
            this._container = container;
        }

        public T ServiceOf<T>() where T : IServiceBase
        {
            return _container.Resolve<T>();
        }
    }
}
