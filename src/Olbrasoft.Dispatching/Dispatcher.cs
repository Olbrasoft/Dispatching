namespace Olbrasoft.Dispatching
{
    using System.Threading;
    using System.Threading.Tasks;

    public class Dispatcher : IDispatcher
    {
        protected ExecutorFactory ExecutorFactory { get; }

        public Dispatcher(ExecutorFactory executorFactory)
        {
            ExecutorFactory = executorFactory;
        }

        public Task<TResponse> DispatchAsync<TResponse>(IRequest<TResponse> request, CancellationToken token = default)
        {
            return Executor(request).ExecuteAsync(request, token);
        }

        private IExecutor<TResponse> Executor<TResponse>(IRequest<TResponse> request)
        {
            var requestType = request.GetType();
            var responseType = typeof(TResponse);

            return ExecutorFactory.CreateExecutor<TResponse>(typeof(Executor<,>).MakeGenericType(requestType, responseType));
        }
    }
}