using Olbrasoft.Dispatching.DI.Grace.Common;
using System;

namespace Olbrasoft.Dispatching.Dynamic.DI.Grace
{
    public static class DispatchingBuilderExtensions
    {
        public static DispatchingBuilder UseDynamicDispatcher(this DispatchingBuilder builder)
        {
            if (builder is not null)
            {
                builder.Scope.Configure(block => block.Export<DynamicDispatcher>().As<IDispatcher>());

                return builder;
            }
            throw new ArgumentNullException(nameof(builder));
        }
    }
}
