using System.Threading;
using System.Threading.Tasks;

namespace Olbrasoft.Dispatching
{
    public interface IDispatcher
    {
        /// <summary>
        /// Runs the query queryHandler registered for the given command type.
        /// If there is no queryHandler for a given query type or there is more than one, this method will throw.
        /// </summary>
        /// <typeparam name="TResponse">Type of the query</typeparam>
        /// <param name="request">Instance of the query</param>
        /// <param name="token">Optional cancellation token</param>
        /// <returns>Task that resolves to a result of the query queryHandler</returns>
        Task<TResponse> DispatchAsync<TResponse>(IRequest<TResponse> request, CancellationToken token);
    }
}