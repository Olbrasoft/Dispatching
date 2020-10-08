using Olbrasoft.Dispatching.Common;
using System.Threading;
using System.Threading.Tasks;

namespace Olbrasoft.Dispatching.WithExecutor
{
    public class Dispatcher : IDispatcher
    {
        private readonly Factory _factory;

        public Dispatcher(Factory Factory)
        {
            _factory = Factory;
        }

        public Task<TResponse> DispatchAsync<TResponse>(IRequest<TResponse> request, CancellationToken token = default)
        {
            return Executor(request).ExecuteAsync(request, token);
        }

        private IExecutor<TResponse> Executor<TResponse>(IRequest<TResponse> request)
        {
            var requestType = request.GetType();
            var responseType = typeof(TResponse);

            return _factory.CreateExecutor<TResponse>(typeof(Executor<,>).MakeGenericType(requestType, responseType));
        }
    }
}