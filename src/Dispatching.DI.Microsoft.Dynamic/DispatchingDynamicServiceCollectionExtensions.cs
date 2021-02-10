using Microsoft.Extensions.DependencyInjection;
using Olbrasoft.Dispatching;
using System.Reflection;

namespace Olbrasoft.Extensions.DependencyInjection
{
    public static class DispatchingDynamicServiceCollectionExtensions
    {
        public static IServiceCollection AddDispatching(this IServiceCollection services, params Assembly[] assemblies)
        {
            services.AddFactoryAndRequestHandlers(assemblies);

            return services.AddScoped<IDispatcher, DynamicDispatcher>();
        }
    }
}