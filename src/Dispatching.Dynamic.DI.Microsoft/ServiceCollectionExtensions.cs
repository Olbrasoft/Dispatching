using Microsoft.Extensions.DependencyInjection;
using Olbrasoft.Dispatching.Abstractions;
using Olbrasoft.Dispatching.DI.Microsoft.Common;
using System;
using System.Reflection;

namespace Olbrasoft.Dispatching.Dynamic.DI.Microsoft
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddDispatching(this IServiceCollection services, params Assembly[] assemblies)
        {
            if (services is null)
                throw new ArgumentNullException(nameof(services));

            if (assemblies is null)
                throw new ArgumentNullException(nameof(assemblies));

            return services.AddFactoryAndRequestHandlers(assemblies)
                 .AddScoped<IDispatcher, DynamicDispatcher>();
        }
    }
}