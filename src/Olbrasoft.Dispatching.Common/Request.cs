using System.Threading;
using System.Threading.Tasks;

namespace Olbrasoft.Dispatching.Common
{
    public class Request<TResponse> : IRequest<TResponse>
    {
        private readonly IRequestHandler<Request<TResponse>, TResponse> _handler;
        private readonly IDispatcher _dispatcher;

        public Request(IRequestHandler<Request<TResponse>, TResponse> handler)
        {
            _handler = handler;
        }

        public Request(IDispatcher dispatcher)
        {
            _dispatcher = dispatcher;
        }

        public virtual async Task<TResponse> ExecuteAsync(CancellationToken token = default)
        {
            if (_handler != null) return await _handler.HandleAsync(this, token);
            return await _dispatcher.DispatchAsync(this, token);
        }
    }
}