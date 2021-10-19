using System;
using System.Threading;
using System.Threading.Tasks;

namespace Olbrasoft.Dispatching
{
    public abstract class DispatcherBase : IDispatcher
    {
        private readonly Factory _factory;

        protected DispatcherBase(Factory factory)
        {
            _factory = factory ?? throw new ArgumentNullException(nameof(factory));
        }

        public abstract Task<TResponse> DispatchAsync<TResponse>(IRequest<TResponse> request, CancellationToken token = default);

        protected THandler GetHandler<THandler>(Type type) where THandler : IHandler
        {
            var adeptHandler = _factory(type) ?? throw new InvalidOperationException($"Could not create handler for type {type}");

            return (THandler)adeptHandler;
        }
    }
}