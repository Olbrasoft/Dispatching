using Microsoft.Extensions.DependencyInjection;
using Olbrasoft.Dispatching.DI.Microsoft.Common;
using System;

namespace Olbrasoft.Dispatching.DI.Microsoft;

public static class DispatchingBuilderExtensions
{
    public static DispatchingBuilder UseDispatcherWithExecutor(this DispatchingBuilder builder)
    {
        if (builder is not null)
        {
            builder.Services.AddScoped(typeof(Executor<,>), typeof(Executor<,>));

            builder.Services.AddScoped<IDispatcher, Dispatcher>();

            return builder;
        }
        throw new ArgumentNullException(nameof(builder));
    }
}