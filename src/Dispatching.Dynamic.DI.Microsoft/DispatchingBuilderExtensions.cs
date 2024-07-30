using Microsoft.Extensions.DependencyInjection;
using Olbrasoft.Dispatching.DI.Microsoft.Common;
using System;

namespace Olbrasoft.Dispatching.Dynamic.DI.Microsoft
{
    public static class DispatchingBuilderExtensions
    {
        public static DispatchingBuilder UseDynamicDispatcher(this DispatchingBuilder builder)
        {
            if (builder is not null)
            {
                builder.Services.AddScoped<IDispatcher, DynamicDispatcher>();

                return builder;
            }

            throw new ArgumentNullException(nameof(builder));
        }
    }
}