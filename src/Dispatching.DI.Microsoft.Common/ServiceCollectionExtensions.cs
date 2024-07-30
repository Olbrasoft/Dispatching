using System;
using System.Linq;
using System.Reflection;
using Microsoft.Extensions.DependencyInjection;


using Olbrasoft.Extensions.Reflection;

namespace Olbrasoft.Dispatching.DI.Microsoft.Common;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddRequestsAndRequestHandlers(this IServiceCollection services, params Assembly[] assemblies)
    {
        if (services is not null)
        {
            if (assemblies is not null)
            {
                foreach (var queryType in assemblies.RequestTypes())
                {
                    services.AddScoped(queryType);
                }

                AddRequestHandlers(services,assemblies);

                return services;
            }

            throw new ArgumentNullException(nameof(assemblies));
        }

        throw new ArgumentNullException(nameof(services));
    }


    public static IServiceCollection AddRequestHandlers(this IServiceCollection services, params Assembly[] assemblies)
    {
        if (services is not null)
        {
            if (assemblies is not null)
            {
                foreach (var typeInfo in assemblies.RequestHandlerTypes())
                {
                    services.AddScoped(typeInfo.GetInterfaces().First(), typeInfo);
                }

                return services;
            }

            throw new ArgumentNullException(nameof(assemblies));
        }

        throw new ArgumentNullException(nameof(services));
    }

    public static IServiceCollection AddFactoryAndRequestHandlers(this IServiceCollection services, params Assembly[] assemblies)
    {
        if (services is not null)
        {
            if (assemblies is not null)
            {
                services.AddRequestHandlers(assemblies);

                return services.AddScoped<Factory>(p => p.GetService!);
            }

            throw new ArgumentNullException(nameof(assemblies));
        }

        throw new ArgumentNullException(nameof(services));
    }

    public static DispatchingBuilder AddDispatching(this IServiceCollection services, params Assembly[] assemblies)
    {
        return services is null
            ? throw new ArgumentNullException(nameof(services))
            : assemblies is null
            ? throw new ArgumentNullException(nameof(assemblies))
            : new DispatchingBuilder (services.AddRequestsAndRequestHandlers(assemblies) );
    }
}
