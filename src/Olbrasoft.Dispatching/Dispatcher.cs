using System.Threading;
using System.Threading.Tasks;

namespace Olbrasoft.Dispatching
{
    public class Dispatcher : IDispatcher
    {
        protected IExecutorFactory ExecutorFactory { get; }

        public Dispatcher(IExecutorFactory executorFactory)
        {
            ExecutorFactory = executorFactory;
        }

        public Task<TResponse> DispatchAsync<TResponse>(IRequest<TResponse> query, CancellationToken token = default)
        {
            var e = Executor(query);

            return e.ExecuteAsync(query, token);
        }

        private IExecutor<TResponse> Executor<TResponse>(IRequest<TResponse> query)
        {
            var queryType = query.GetType();
            var resultType = typeof(TResponse);


            var a = ExecutorFactory.Get<TResponse>(typeof(Executor<,>).MakeGenericType(queryType, resultType));

            return a;
        }
    }
}