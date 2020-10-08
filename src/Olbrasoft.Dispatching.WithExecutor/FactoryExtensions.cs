using Olbrasoft.Dispatching.Common;
using System;

namespace Olbrasoft.Dispatching.WithExecutor
{
    public static class FactoryExtensions
    {
        public static IExecutor<TResult> CreateExecutor<TResult>(this Factory factory, Type type) => (IExecutor<TResult>)factory(type);
    }
}