using System.Threading;
using System.Threading.Tasks;

namespace Olbrasoft.Dispatching.Abstractions.Awesomes;

public class AwesomeRequestHandlerTwo : IRequestHandler<AwesomeRequestTwo,string>
{
    public Task<string> HandleAsync(AwesomeRequestTwo request, CancellationToken token)
    {
        return Task.FromResult("Hello World! Handled AwesomeRequestHandlerTwo");
    }
}
