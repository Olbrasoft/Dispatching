using System;

namespace Olbrasoft.Dispatching
{
    public static class ExecutorFactoryExtensions
    {
        public static IExecutor<TResult> CreateExecutor<TResult>(this ExecutorFactory factory, Type type) => (IExecutor<TResult>)factory(type);
    }
}