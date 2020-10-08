using Microsoft.Extensions.DependencyInjection;
using Olbrasoft.Dispatching.Common;
using System.Linq;
using System.Reflection;

namespace Olbrasoft.Dispatching.DependencyInjection.Microsoft
{
    public static class ServiceCollectionExtensions
    {
        public static void AddRequestsAndRequestHandlers(this IServiceCollection services, params Assembly[] assemblies)
        {
            foreach (var queryType in assemblies.RequestTypes())
            {
                services.AddTransient(queryType);
            }

            foreach (var typeInfo in assemblies.RequestHandlerTypes())
            {
                services.AddTransient(typeInfo.GetInterfaces().First(), typeInfo);
            }
        }

        public static void AddRequestHandlers(this IServiceCollection services, params Assembly[] assemblies)
        {
            foreach (var typeInfo in assemblies.RequestHandlerTypes())
            {
                services.AddTransient(typeInfo.GetInterfaces().First(), typeInfo);
            }
        }

        public static void AddFactoryAndRequestHandlers(this IServiceCollection services, params Assembly[] assemblies)
        {
            services.AddRequestHandlers(assemblies);
            services.AddSingleton<Factory>(p => p.GetService);
        }
    }
}