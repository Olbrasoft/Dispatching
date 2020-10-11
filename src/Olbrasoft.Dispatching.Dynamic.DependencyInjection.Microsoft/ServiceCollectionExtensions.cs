using Microsoft.Extensions.DependencyInjection;
using Olbrasoft.Dispatching.Common;
using Olbrasoft.Dispatching.DependencyInjection.Microsoft;
using System.Reflection;

namespace Olbrasoft.Dispatching.Dynamic.DependencyInjection.Microsoft.Tests
{
    public static class ServiceCollectionExtensions
    {
        public static void AddDispatching(this IServiceCollection services, params Assembly[] assemblies)
        {
            services.AddFactoryAndRequestHandlers(assemblies);

            services.AddScoped<IDispatcher, DynamicDispatcher>();
        }
    }
}