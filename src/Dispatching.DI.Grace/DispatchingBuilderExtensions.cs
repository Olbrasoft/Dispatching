using Olbrasoft.Dispatching.DI.Grace.Common;
using System;

namespace Olbrasoft.Dispatching.DI.Grace
{
    public static class DispatchingBuilderExtensions
    {
        public static DispatchingBuilder UseDispatcherWithExecutor(this DispatchingBuilder builder)
        {
            if (builder is not null)
            {
             
                builder.Scope.Configure(block => block.Export(typeof(Executor<,>)).As(typeof(Executor<,>)).Lifestyle.SingletonPerRequest());

                builder.Scope.Configure(block => block.Export<Dispatcher>().As<IDispatcher>());

                return builder;
            }

            throw new ArgumentNullException(nameof(builder));
        }
    }
}
