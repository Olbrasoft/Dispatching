using System.Collections.Concurrent;

namespace Olbrasoft.Dispatching;

public abstract class BaseDispatcher : IDispatcher
{
    private readonly ConcurrentDictionary<Type, IHandler> _handlers = new();

    private readonly CreateHandler _createHandler;

    //https://learn.microsoft.com/en-us/dotnet/standard/design-guidelines/names-of-type-members#names-of-events
    public event EventHandler<SendEventArgs>? Sending;

    public event EventHandler<SendEventArgs>? Sended;

    public BaseDispatcher(CreateHandler createHandler) =>
         _createHandler = createHandler ?? throw new CreateHandlerNullException();

    public virtual async Task<TResponse> DispatchAsync<TResponse>(IRequest<TResponse> request, CancellationToken token = default)
    {
        OnSending(request);

        var response = await SendAsync(request, token);

        OnSended(request, response);

        return response;
    }

    protected abstract Task<TResponse> SendAsync<TResponse>(IRequest<TResponse> request, CancellationToken token = default);

    public THandler GetHandler<THandler>(Type exactHandlerType) where THandler : IHandler
    {
        return (THandler)_handlers.GetOrAdd(exactHandlerType, t
            => (THandler)_createHandler(exactHandlerType) ?? throw new CreateHandlerException(exactHandlerType));
    }

    private void OnSending<TResponse>(IRequest<TResponse> request)
    {
        if (Sending is not null) 
            Sending(this, new SendEventArgs(request));
    }

    private void OnSended<TResponse>(IRequest<TResponse> request, TResponse response)
    {
        if (Sended is not null)
            Sended(this, new SendEventArgs(request, response));
    }
}