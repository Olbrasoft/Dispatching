using System.Threading;
using System.Threading.Tasks;

namespace Olbrasoft.Dispatching

{
    public class Executor<TRequest, TResponse> : IExecutor<TResponse> where TRequest : IRequest<TResponse>
    {
        private readonly IRequestHandler<TRequest, TResponse> _handler;

        public Executor(IRequestHandler<TRequest, TResponse> handler)
        {
            _handler = handler;
        }

        public Task<TResponse> ExecuteAsync(IRequest<TResponse> query, CancellationToken token = default)
        {
            return _handler.HandleAsync((TRequest)query, token);
        }
    }
}