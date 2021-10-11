using System;
using System.Reflection;
using Microsoft.Extensions.DependencyInjection;
using Olbrasoft.Dispatching.Abstractions;
using Olbrasoft.Dispatching.DI.Microsoft.Common;

namespace Olbrasoft.Dispatching.DI.Microsoft
{
    public static class ServiceCollectionExtensions

    {
        public static IServiceCollection AddDispatching(this IServiceCollection services, params Assembly[] assemblies)
        {
            if (services is null)
                throw new ArgumentNullException(nameof(services));

            if (assemblies is null)
                throw new ArgumentNullException(nameof(assemblies));

            services.AddScoped(typeof(Executor<,>), typeof(Executor<,>));

            services.AddScoped<IDispatcher, Dispatcher>();

            return services.AddFactoryAndRequestHandlers(assemblies);
        }
    }
}