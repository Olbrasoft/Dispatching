using Olbrasoft.Extensions.Reflection;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Olbrasoft.Dispatching;

namespace Olbrasoft.Extensions.DependencyInjection;

public static class ServiceCollectionExtensions
{

    /// <summary>
    /// Registers handlers and dispatcher types from the specified assemblies
    /// </summary>
    /// <param name="services">Service collection</param>
    /// <param name="assemblies">Assemblies to scan</param>
    /// <param name="configuration">The action used to configure the options</param>
    /// <returns>Service collection</returns>
    public static IServiceCollection AddDispatching(this IServiceCollection services, IEnumerable<Assembly> assemblies, Action<DispatchingServiceConfiguration>? configuration)
    {
        if (!assemblies.Any())
            throw new ArgumentException("No assemblies found to scan. Supply at least one assembly to scan for handlers.");

        var serviceConfiguration = new DispatchingServiceConfiguration();

        configuration?.Invoke(serviceConfiguration);

        services.TryAddTransient<Factory>(p => p.GetRequiredService);

        services.TryAdd(new ServiceDescriptor(typeof(IDispatcher), serviceConfiguration.DispatcherType, serviceConfiguration.Lifetime));

        foreach (var typeInfo in assemblies.RequestHandlerTypes())
        {
            services.TryAddTransient(typeInfo.GetInterfaces().First(), typeInfo);
        }

        return services;
    }

    /// <summary>
    /// Registers handlers and dispatcher types from the assemblies that contain the specified types
    /// </summary>
    /// <param name="services"></param>
    /// <param name="handlerAssemblyMarkerTypes"></param>
    /// <param name="configuration">The action used to configure the options</param>
    /// <returns>Service collection</returns>
    public static IServiceCollection AddDispatching(this IServiceCollection services, IEnumerable<Type> handlerAssemblyMarkerTypes, Action<DispatchingServiceConfiguration>? configuration)
        => services.AddDispatching(handlerAssemblyMarkerTypes.Select(t => t.GetTypeInfo().Assembly), configuration);


    /// <summary>
    /// Registers handlers and dispatcher types from the specified assemblies
    /// </summary>
    /// <param name="services">Service collection</param>
    /// <param name="assemblies">Assemblies to scan</param>        
    /// <returns>Service collection</returns>
    public static IServiceCollection AddDispatching(this IServiceCollection services, params Assembly[] assemblies)
    {
        return services.AddDispatching(assemblies, configuration: null);
    }


    ///// <summary>
    ///// Registers handlers and dispatcher types from the specified assemblies
    ///// </summary>
    ///// <param name="services">Service collection</param>
    ///// <param name="assemblies">Assemblies to scan</param>
    ///// <param name="configuration">The action used to configure the options</param>
    ///// <returns>Service collection</returns>
    //public static IServiceCollection AddDispatching(this IServiceCollection services, Action<DispatchingServiceConfiguration>? configuration, params Assembly[] assemblies)
    //{
    //    return services.AddDispatching(assemblies, configuration);
    //}
}