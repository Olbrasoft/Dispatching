using System.Threading;
using System.Threading.Tasks;

namespace Olbrasoft.Dispatching
{
    public interface IRequestHandler<in TRequest, TResponse>
    {
        /// <summary>
        /// Handles a request
        /// </summary>
        /// <param name="request">The request</param>
        /// <param name="cancellationToken">Cancellation token</param>
        /// <returns>Response from the request</returns>
        Task<TResponse> HandleAsync(TRequest request, CancellationToken cancellationToken);
    }
}