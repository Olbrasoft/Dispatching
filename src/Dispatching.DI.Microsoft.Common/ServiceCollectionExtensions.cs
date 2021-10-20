using System;
using System.Linq;
using System.Reflection;
using Microsoft.Extensions.DependencyInjection;
using Olbrasoft.Extensions.Reflection;

namespace Olbrasoft.Dispatching.DI.Microsoft.Common
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddRequestsAndRequestHandlers(this IServiceCollection services, params Assembly[] assemblies)
        {
            if (services is null)
                throw new ArgumentNullException(nameof(services));

            if (assemblies is null)
                throw new ArgumentNullException(nameof(assemblies));

            foreach (var queryType in assemblies.RequestTypes())
            {
                services.AddScoped(queryType);
            }

            foreach (var typeInfo in assemblies.RequestHandlerTypes())
            {
                services.AddScoped(typeInfo.GetInterfaces().First(), typeInfo);
            }

            return services;
        }

        public static IServiceCollection AddRequestHandlers(this IServiceCollection services, params Assembly[] assemblies)
        {
            if (services is null)
                throw new ArgumentNullException(nameof(services));

            if (assemblies is null)
                throw new ArgumentNullException(nameof(assemblies));

            foreach (var typeInfo in assemblies.RequestHandlerTypes())
            {
                services.AddScoped(typeInfo.GetInterfaces().First(), typeInfo);
            }

            return services;
        }

        public static IServiceCollection AddFactoryAndRequestHandlers(this IServiceCollection services, params Assembly[] assemblies)
        {
            if (services is null)
                throw new ArgumentNullException(nameof(services));

            if (assemblies is null)
                throw new ArgumentNullException(nameof(assemblies));

            services.AddRequestHandlers(assemblies);

            return services.AddScoped<Factory>(p => p.GetService);
        }
    }
}