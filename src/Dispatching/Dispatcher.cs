using System.Threading;
using System.Threading.Tasks;

namespace Olbrasoft.Dispatching
{
    public class Dispatcher : DispatcherBase
    {
        public Dispatcher(Factory factory) : base(factory)
        {
        }

        public override Task<TResponse> DispatchAsync<TResponse>(IRequest<TResponse> request, CancellationToken token = default)
        {
            var executor = GetHandler<IExecutor<TResponse>>(typeof(Executor<,>)
                    .MakeGenericType(request.GetType(), typeof(TResponse)));

            return executor.ExecuteAsync(request, token);
        }
    }
}