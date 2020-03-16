using Olbrasoft.Dispatching;
using System.Threading;
using System.Threading.Tasks;

namespace Olbrasoft.Data.Cqrs
{
    public abstract class Request<TResponse> : IRequest<TResponse>
    {
        protected IDispatcher Dispatcher { get; }

        protected Request()
        {
        }

        protected Request(IDispatcher dispatcher)
        {
            Dispatcher = dispatcher;
        }

        protected async Task<TResponse> ExecuteWithDispatcherAsync(CancellationToken token = default)
        {
            return await Dispatcher.DispatchAsync(this, token);
        }

        public abstract Task<TResponse> ExecuteAsync();
    }
}