using System;

namespace Olbrasoft.Dispatching
{
    public interface IExecutorFactory
    {
        IExecutor<TResponse> Get<TResponse>(Type executorType);
    }
}