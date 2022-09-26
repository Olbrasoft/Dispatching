using Olbrasoft.Dispatching;
using System.Threading;
using System.Threading.Tasks;

namespace Olbrasoft.Extensions.DependencyInjection;

internal class AwesomeDispatcher : IDispatcher
{
    public AwesomeDispatcher()
    {
    }

    public Task<TResponse> DispatchAsync<TResponse>(IRequest<TResponse> request, CancellationToken token)
    {
        throw new System.NotImplementedException();
    }
}