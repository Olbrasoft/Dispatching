using System.Threading;
using System.Threading.Tasks;

namespace Olbrasoft.Dispatching
{
    public abstract class RequestHandler<TRequest, TResponse> : IRequestHandler<TRequest, TResponse> where TRequest : Request<TResponse>
    {
        public abstract Task<TResponse> HandleAsync(TRequest request, CancellationToken token);
    }
}