namespace Olbrasoft.Dispatching;

public interface IExecutor<TResponse> : IHandler
{
    Task<TResponse> ExecuteAsync(IRequest<TResponse> query, CancellationToken token);
}