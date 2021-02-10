using Microsoft.Extensions.DependencyInjection;
using Olbrasoft.Dispatching;
using Olbrasoft.Dispatching.WithExecutor;
using System.Reflection;

namespace Olbrasoft.Extensions.DependencyInjection
{
    public static class DispatchingWithExecutorServiceCollectionExtensions

    {
        public static IServiceCollection AddDispatching(this IServiceCollection services, params Assembly[] assemblies)
        {
            services.AddScoped(typeof(Executor<,>), typeof(Executor<,>));

            services.AddScoped<IDispatcher, Dispatcher>();

            return services.AddFactoryAndRequestHandlers(assemblies);
        }
    }
}