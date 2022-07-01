using System;
using System.Reflection;
using Grace.DependencyInjection;
using Olbrasoft.Dispatching;
using Olbrasoft.Dispatching.DI.Grace.Common;

namespace Olbrasoft.Extensions.DependencyInjection;

public static class InjectionScopeExtensions
{
    public static IInjectionScope AddDispatching(this IInjectionScope scope, params Assembly[] assemblies)
    {
        if (scope is null)
            throw new ArgumentNullException(nameof(scope));

        if (assemblies is null)
            throw new ArgumentNullException(nameof(assemblies));

        scope.Configure(block => block.Export<DynamicDispatcher>().As<IDispatcher>().Lifestyle.SingletonPerRequest());

        return scope.AddFactoryAndRequestHandlers(assemblies);
    }
}