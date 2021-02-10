using Microsoft.Extensions.DependencyInjection;
using Olbrasoft.Dispatching;
using Olbrasoft.Extensions.Reflection;
using System.Linq;
using System.Reflection;

namespace Olbrasoft.Extensions.DependencyInjection
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddRequestsAndRequestHandlers(this IServiceCollection services, params Assembly[] assemblies)
        {
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
            foreach (var typeInfo in assemblies.RequestHandlerTypes())
            {
                services.AddScoped(typeInfo.GetInterfaces().First(), typeInfo);
            }

            return services;
        }

        public static IServiceCollection AddFactoryAndRequestHandlers(this IServiceCollection services, params Assembly[] assemblies)
        {
            services.AddRequestHandlers(assemblies);

            return services.AddScoped<Factory>(p => p.GetService);
        }
    }
}