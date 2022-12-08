using System.Threading;
using System.Threading.Tasks;

namespace Olbrasoft.Dispatching.Abstractions;
public class PingDispatcher : BaseDispatcher
{
    public PingDispatcher(CreateHandler createHandler) : base(createHandler)
    {
    }

    protected override async Task<TResponse> SendAsync<TResponse>(IRequest<TResponse> request, CancellationToken token = default) 
    {
        var result =(TResponse) new object();

        return await Task.FromResult(result);
    }
}
