using System.Threading;
using System.Threading.Tasks;

namespace Olbrasoft.Dispatching
{
    public class Request<TResponse> : IRequest<TResponse>
    {
        public IRequestHandler<Request<TResponse>, TResponse> Handler { get; }

        public IDispatcher Dispatcher { get; }

        public Request(IRequestHandler<Request<TResponse>, TResponse> handler)
        {
            Handler = handler;
        }

        public Request(IDispatcher dispatcher)
        {
            Dispatcher = dispatcher;
        }

        public async Task<TResponse> ExecuteWithDispatcherAsync(CancellationToken token = default)
        {
            return await Dispatcher.DispatchAsync(this, token);
        }

        public async Task<TResponse> ExecuteWithHandler(CancellationToken token = default)
        {
            return await Handler.HandleAsync(this, token);
        }

        public virtual async Task<TResponse> ExecuteAsync(CancellationToken token = default)
        {
            if (Handler != null) return await ExecuteWithHandler(token);

            return await ExecuteWithDispatcherAsync(token);
        }
    }
}