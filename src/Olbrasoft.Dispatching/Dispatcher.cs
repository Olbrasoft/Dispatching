namespace Olbrasoft.Dispatching
{
    using System.Threading;
    using System.Threading.Tasks;

    /// <summary>
    /// Default mediator implementation relying on single- and multi instance delegates for resolving handlers.
    /// </summary>
    public class Dispatcher : IDispatcher
    {
        protected IExecutorFactory ExecutorFactory { get; }

        public Dispatcher(IExecutorFactory executorFactory)
        {
            ExecutorFactory = executorFactory;
        }

        public Task<TResult> DispatchAsync<TResult>(IRequest<TResult> query, CancellationToken token = default)
        {
            var e = Executor(query);

            return e.ExecuteAsync(query, token);
        }

        private IExecutor<TResult> Executor<TResult>(IRequest<TResult> query)
        {
            var queryType = query.GetType();
            var resultType = typeof(TResult);

            var a = ExecutorFactory.Get<TResult>(typeof(Executor<,>).MakeGenericType(queryType, resultType));

            return a;
        }
    }
}
