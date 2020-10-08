using System.Threading;
using System.Threading.Tasks;

namespace Olbrasoft.Dispatching.Common
{
    /// <summary>
    /// Defines a dispatcher to encapsulate request/response and publishing interaction patterns
    /// </summary>
    public interface IDispatcher
    {
        /// <summary>
        /// Asynchronously send a request to a single handler
        /// </summary>
        /// <typeparam name="TResponse">Response type</typeparam>
        /// <param name="request">Request object</param>
        /// <param name="token">The CancellationToken</param>
        /// <returns>A task that represents the send operation. The task result contains the handler response</returns>
        Task<TResponse> DispatchAsync<TResponse>(IRequest<TResponse> request, CancellationToken token);
    }
}