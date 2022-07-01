using Grace.DependencyInjection;
using Olbrasoft.Dispatching;
using System;
using System.Reflection;
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

        scope.Configure(block => block.Export(typeof(Executor<,>)).As(typeof(Executor<,>)).Lifestyle.SingletonPerRequest());

        scope.Configure(block => block.Export<Dispatcher>().As<IDispatcher>());

        return scope.AddFactoryAndRequestHandlers(assemblies);
    }
}