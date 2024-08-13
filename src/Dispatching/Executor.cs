namespace Olbrasoft.Dispatching;

public class Executor<TRequest, TResponse> : IExecutor<TResponse> where TRequest : IRequest<TResponse>
{
    private readonly IRequestHandler<TRequest, TResponse> _handler;

    public Executor(IRequestHandler<TRequest, TResponse> handler)
    {
        _handler = handler ?? throw new System.ArgumentNullException(nameof(handler));
    }

    public async Task<TResponse> ExecuteAsync(IRequest<TResponse> query, CancellationToken token = default)
    {
        return query is null ? throw new System.ArgumentNullException(nameof(query)) : await _handler.HandleAsync((TRequest)query, token);
    }
}