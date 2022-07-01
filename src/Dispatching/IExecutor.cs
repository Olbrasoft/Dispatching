namespace Olbrasoft.Dispatching;

public interface IExecutor<TResult> : IHandler
{
    Task<TResult> ExecuteAsync(IRequest<TResult> query, CancellationToken token);
}