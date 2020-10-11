using Microsoft.Extensions.DependencyInjection;
using Olbrasoft.Dispatching.Common;
using Olbrasoft.Dispatching.DependencyInjection.Microsoft;
using System.Reflection;

namespace Olbrasoft.Dispatching.WithExecutor.DependencyInjection.Microsoft
{
    public static class ServiceCollectionExtensions
    {
        public static void AddDispatching(this IServiceCollection services, params Assembly[] assemblies)
        {
            services.AddScoped(typeof(Executor<,>), typeof(Executor<,>));

            services.AddScoped<IDispatcher, Dispatcher>();

            services.AddFactoryAndRequestHandlers(assemblies);
        }
    }
}