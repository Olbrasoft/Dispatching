using System;
using System.Linq;
using System.Reflection;
using Grace.DependencyInjection;
using Grace.DependencyInjection.Extensions;
using Olbrasoft.Extensions.Reflection;

namespace Olbrasoft.Dispatching.DI.Grace.Common
{
    public static class InjectionScopeExtensions
    {
        public static IInjectionScope AddFactoryAndRequestHandlers(this IInjectionScope scope, params Assembly[] assemblies)
        {
            if (scope is null)
                throw new ArgumentNullException(nameof(scope));

            if (assemblies is null)
                throw new ArgumentNullException(nameof(assemblies));

            scope.Configure(block => block.ExportFunc<Factory>(p => p.GetService!));

            foreach (var typeInfo in assemblies.RequestHandlerTypes())
            {
                scope.Configure(block => block.Export(typeInfo).As(typeInfo.GetInterfaces().First()).Lifestyle.SingletonPerRequest());
            }

            return scope;
        }
    }
}