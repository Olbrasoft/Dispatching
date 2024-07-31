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
        public static DispatchingBuilder AddDispatching(this IInjectionScope scope, params Assembly[] assemblies)
        {
            if (scope is not null)
            {
                if (assemblies is not null)
                {
                    scope.Configure(block => block.ExportFunc<Factory>(p => p.GetService!));

                    foreach (var typeInfo in assemblies.RequestHandlerTypes())
                    {
                        scope.Configure(block => block.Export(typeInfo).As(typeInfo.GetInterfaces().First()).Lifestyle.SingletonPerRequest());
                    }

                    return new DispatchingBuilder(scope);
                }
                else
                {
                    throw new ArgumentNullException(nameof(assemblies));
                }
            }
            throw new ArgumentNullException(nameof(scope));
        }
    }
}