using System.Threading;
using System.Threading.Tasks;
using Olbrasoft.Dispatching.Abstractions;

namespace Olbrasoft.Dispatching
{
    public class Executor<TRequest, TResponse> : IExecutor<TResponse> where TRequest : IRequest<TResponse>
    {
        private readonly IRequestHandler<TRequest, TResponse> _handler;

        public Executor(IRequestHandler<TRequest, TResponse> handler)
        {
            _handler = handler;
        }

        public async Task<TResponse> ExecuteAsync(IRequest<TResponse> query, CancellationToken token = default)
        {
            return await _handler.HandleAsync((TRequest)query, token);
        }
    }
}