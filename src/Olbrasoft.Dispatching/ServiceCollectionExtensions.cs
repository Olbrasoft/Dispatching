using System.Linq;
using System.Reflection;
using Microsoft.Extensions.DependencyInjection;
using Olbrasoft.Querying.DependencyInjection;

namespace Olbrasoft.Dispatching
{
    public static class ServiceCollectionExtensions
    {
        public static void AddDispatching(this IServiceCollection services)
        {

            services.AddScoped(typeof(Executor<,>), typeof(Executor<,>));

            services.AddSingleton<IExecutorFactory, ExecutorFactory>();

            services.AddSingleton<IDispatcher, Dispatcher>();
        }

        public static void AddDispatching(this IServiceCollection services, params Assembly[] assemblies)
        {
            services.AddDispatching();

            foreach (var queryType in assemblies.GetQueryTypes())
            {
                services.AddScoped(queryType);
            }

            foreach (var typeInfo in assemblies.GetQueryHandlerTypes())
            {
                services.AddScoped(typeInfo.GetInterfaces().First(), typeInfo);
            }
        }
    }
}