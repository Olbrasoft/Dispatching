using Olbrasoft.Dispatching;
using Olbrasoft.Dispatching.WithExecutor;
using System;

namespace Olbrasoft.Extensions.Dispatching
{
    public static class FactoryExtensions
    {
        public static IExecutor<TResult> CreateExecutor<TResult>(this Factory factory, Type type) => (IExecutor<TResult>)factory(type);
    }
}