using System;
using System.Threading;
using System.Threading.Tasks;

namespace Olbrasoft.Dispatching
{
    public class Request<TResponse> : IRequest<TResponse>
    {
        private readonly IRequestHandler<Request<TResponse>, TResponse> _handler;
        private readonly IDispatcher _dispatcher;

        public Request(IRequestHandler<Request<TResponse>, TResponse> handler)
        {
            _handler = handler ?? throw new ArgumentNullException(nameof(handler));
        }

        public Request(IDispatcher dispatcher)
        {
            _dispatcher = dispatcher ?? throw new ArgumentNullException(nameof(dispatcher));
        }

        public virtual async Task<TResponse> ExecuteAsync(CancellationToken token = default)
        {
            // ReSharper disable once ConditionIsAlwaysTrueOrFalse
            return (_handler is null) ? await _dispatcher.DispatchAsync(this, token) : await _handler.HandleAsync(this, token);
        }
    }
}