using Microsoft.Extensions.DependencyInjection;
using System;

namespace Olbrasoft.Dispatching
{
    public class ExecutorFactory : IExecutorFactory
    {
        private IServiceProvider _provider;
        private readonly IServiceScopeFactory _factory;

        protected IServiceProvider Provider => _provider ?? (_provider = _factory.CreateScope().ServiceProvider);

        public ExecutorFactory(IServiceScopeFactory factory)
        {
            _factory = factory;
        }

        public IExecutor<TResult> Get<TResult>(Type executorType)
        {
            return (IExecutor<TResult>)Provider.GetService(executorType);
        }
    }
}