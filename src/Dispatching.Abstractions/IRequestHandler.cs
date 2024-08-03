namespace Olbrasoft.Dispatching;

/// <summary>
/// Defines a handler for a request
/// </summary>
/// <typeparam name="TRequest">The type of request being handled</typeparam>
/// <typeparam name="TResponse">The type of response from the handler</typeparam>
public interface IRequestHandler<TRequest, TResponse> : IHandler where TRequest : IRequest<TResponse>
{
    /// <summary>
    /// Handles a request
    /// </summary>
    /// <param name="request">The request</param>
    /// <param name="token">The CancellationToken</param>
    /// <returns>Response from the request</returns>
    Task<TResponse> HandleAsync(TRequest request, CancellationToken token);
}