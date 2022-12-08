namespace Olbrasoft.Dispatching;

public class Executor<TRequest, TResponse> : IExecutor<TResponse> where TRequest : IRequest<TResponse>
{
    private readonly IRequestHandler<TRequest, TResponse> _handler;

    public Executor(IRequestHandler<TRequest, TResponse> handler)
    {
        _handler = handler;
    }

    public async Task<TResponse> ExecuteAsync(IRequest<TResponse> request, CancellationToken token = default)
    {
        if (request is null)
            throw new RequestNullException();

        return await _handler.HandleAsync((TRequest)request, token);
    }
}