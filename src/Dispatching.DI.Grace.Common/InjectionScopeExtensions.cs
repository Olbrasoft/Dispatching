using Grace.DependencyInjection;
using Olbrasoft.Dispatching.DI.Common;
using System;
using System.Linq;
using System.Reflection;

namespace Olbrasoft.Dispatching.DI.Grace.Common
{
    public static class InjectionScopeExtensions
    {
        public static IInjectionScope AddRequestHandlers(this IInjectionScope scope, params Assembly[] assemblies)
        {
            if (scope is null)
                throw new ArgumentNullException(nameof(scope));

            if (assemblies is null)
                throw new ArgumentNullException(nameof(assemblies));

            foreach (var typeInfo in assemblies.RequestHandlerTypes())
            {
                scope.Configure(block => block.Export(typeInfo).As(typeInfo.GetInterfaces().First()).Lifestyle.SingletonPerRequest());
            }

            return scope;
        }
    }
}