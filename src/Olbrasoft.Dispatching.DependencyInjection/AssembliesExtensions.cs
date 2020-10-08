using Olbrasoft.Extensions;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace Olbrasoft.Dispatching.DependencyInjection
{
    public static class AssembliesExtensions
    {
        private static IEnumerable<TypeInfo> AllTypes(IEnumerable<Assembly> assemblies)
        {
            return assemblies.Where(a => !a.IsDynamic && a.GetName().Name != typeof(IRequest<>).Assembly.GetName().Name).Distinct()
                .SelectMany(a => a.DefinedTypes).Where(c => c.IsClass && !c.IsAbstract);
        }

        public static IEnumerable<TypeInfo> RequestTypes(this IEnumerable<Assembly> assemblies)
        {
            var requestGenericInterfaceType = new[] { typeof(IRequest<>) };

            return requestGenericInterfaceType.SelectMany(openType => AllTypes(assemblies)
                 .Where(t => t.AsType().ImplementsGenericInterface(openType)));
        }

        public static IEnumerable<TypeInfo> RequestHandlerTypes(this IEnumerable<Assembly> assemblies)
        {
            var handlerGenericInterfaceType = new[] { typeof(IRequestHandler<,>) };

            return handlerGenericInterfaceType.SelectMany(openType => AllTypes(assemblies)
                 .Where(t => t.AsType().ImplementsGenericInterface(openType)));
        }
    }
}