using System.Threading;
using System.Threading.Tasks;

namespace Olbrasoft.Dispatching.Abstractions.Awesomes;

public class AwesomeRequestHandler : IRequestHandler<AwesomeRequest, string>
{
    public Task<string> HandleAsync(AwesomeRequest request, CancellationToken token)
    {
        return Task.FromResult("Hello World!");
    }
}
