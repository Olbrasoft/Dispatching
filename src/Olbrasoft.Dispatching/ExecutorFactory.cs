using System;

namespace Olbrasoft.Dispatching
{
    public class ExecutorFactory : IExecutorFactory
    {
        ServiceFactory _factory;

        public ExecutorFactory(ServiceFactory factory)
        {
            _factory = factory;
        }

        public IExecutor<TResult> Get<TResult>(Type executorType)
        {
            return (IExecutor<TResult>)_factory.GetInstance(executorType);
        }
    }
}