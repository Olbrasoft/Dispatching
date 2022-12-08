using System.Threading;
using System.Threading.Tasks;

namespace Olbrasoft.Dispatching.Abstractions
{
    public class AwesomeDispatcher : BaseDispatcher
    {
        public AwesomeDispatcher(CreateHandler createHandler) : base(createHandler)
        {
        }
              

        public IHandler CallProtectedFunctionGetHandler()
        {
             return GetHandler<IHandler>(typeof(AwesomeHandler));
        }

        protected override Task<TResponse> SendAsync<TResponse>(IRequest<TResponse> request, CancellationToken token = default)
        {
            throw new NotImplementedException();
        }
    }
}