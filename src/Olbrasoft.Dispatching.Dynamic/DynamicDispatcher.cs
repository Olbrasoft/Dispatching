using Olbrasoft.Dispatching.Common;
using System.Threading;
using System.Threading.Tasks;

namespace Olbrasoft.Dispatching.Dynamic
{
    public class DynamicDispatcher : IDispatcher
    {
        private readonly Factory _factory;

        public DynamicDispatcher(Factory factory)
        {
            _factory = factory;
        }

        public Task<TResponse> DispatchAsync<TResponse>(IRequest<TResponse> request, CancellationToken token = default)
        {
            var handlerType = typeof(IRequestHandler<,>).MakeGenericType(request.GetType(), typeof(TResponse));

            dynamic handler = _factory.CreateHandler(handlerType);

            return handler.HandleAsync((dynamic)request, token);
        }
    }
}