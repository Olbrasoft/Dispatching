using System.Threading;
using System.Threading.Tasks;

namespace Olbrasoft.Dispatching

{
    public class Executor<TRequest, TResponse> : IExecutor<TResponse> where TRequest : IRequest<TResponse>
    {
        private readonly IRequestHandler<TRequest, TResponse> _queryHandler;

        public Executor(IRequestHandler<TRequest, TResponse> queryHandler)
        {
            _queryHandler = queryHandler;
        }
        public Task<TResponse> ExecuteAsync(IRequest<TResponse> query, CancellationToken token = default)
        {
            return _queryHandler.HandleAsync((TRequest)query, token);
        }
    }
}