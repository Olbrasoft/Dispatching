
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Transactions;

namespace Olbrasoft.Dispatching;

public abstract class BaseDispatcher : IDispatcher
{
    private readonly Factory _factory;

    protected BaseDispatcher(Factory factory)
    {
        _factory = factory;
    }

    protected BaseDispatcher()
    {
        
    }

    public abstract Task<TResponse> DispatchAsync<TResponse>(IRequest<TResponse> request, CancellationToken token = default);
            

    protected virtual THandler GetHandler<THandler>(Type type) where THandler : IHandler
    {
        if (type is not null)
        {
            var adeptHandler = _factory(type) ?? throw new InvalidOperationException($"Could not create handler for type {type}");
            return (THandler)adeptHandler;
        }

        throw new ArgumentNullException(nameof(type));
    }


}