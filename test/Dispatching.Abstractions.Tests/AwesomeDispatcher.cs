using System.Threading;
using System.Threading.Tasks;

namespace Olbrasoft.Dispatching.Abstractions
{
    public class AwesomeDispatcher : DispatcherBase
    {
        public AwesomeDispatcher(Factory factory) : base(factory)
        {
        }

        public override Task<TResponse> DispatchAsync<TResponse>(IRequest<TResponse> request, CancellationToken token = default)
        {
            throw new System.NotImplementedException();
        }

        public IHandler CallProtectedFunctionGetHandler()
        {
            return base.GetHandler<IHandler>(typeof(AwesomeHandler));
        }
    }
}