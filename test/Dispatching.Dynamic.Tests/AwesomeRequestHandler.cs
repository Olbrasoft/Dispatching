using Olbrasoft.Dispatching;
using System.Threading;
using System.Threading.Tasks;

namespace Dispatching.Dynamic.Tests
{
    public class AwesomeRequestHandler : IRequestHandler<AwesomeRequest, AwesomeResponse>
    {
        public Task<AwesomeResponse> HandleAsync(AwesomeRequest request, CancellationToken token)
        {
            return Task.FromResult(new AwesomeResponse());
        }
    }
}