
using Autofac;
using Autofac.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection;

namespace EmployeeManagement.IoC
{
    public class ContainerManager
    {
        private static IContainer _container;
        public static  IContainer BuildContainer(IServiceCollection serviceCollection = null)
        {
            var containerBuilder = new ContainerBuilder();
            containerBuilder.RegisterModule<DefaultModule>();
            if (serviceCollection != null)
            {
                containerBuilder.Populate(serviceCollection);
            }
            _container = containerBuilder.Build();
            return _container;
        }

        public static T Resolve<T>()
        {
        return _container.Resolve<T>();
        }
    }
}