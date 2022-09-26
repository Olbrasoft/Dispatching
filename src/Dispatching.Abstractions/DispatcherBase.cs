using System.Collections.Concurrent;

namespace Olbrasoft.Dispatching;

public abstract class DispatcherBase : IDispatcher
{
    private static readonly ConcurrentDictionary<Type, IHandler> _handlers = new();
    private readonly Factory _factory;

    public DispatcherBase(Factory factory) =>
         _factory = factory ?? throw new ArgumentNullException(nameof(factory));

    public abstract Task<TResponse> DispatchAsync<TResponse>(IRequest<TResponse> request, CancellationToken token = default);

    public THandler GetHandler<THandler>(Type exactHandlerType) where THandler : IHandler
    {        
        return (THandler)_handlers.GetOrAdd(exactHandlerType, t
            => (THandler)_factory(exactHandlerType) ?? throw new InvalidOperationException($"Could not create handler for type {exactHandlerType}"));
    }
}
