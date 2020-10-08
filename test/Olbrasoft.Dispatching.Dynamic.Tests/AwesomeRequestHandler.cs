using Olbrasoft.Dispatching.Common;
using System.Threading;
using System.Threading.Tasks;

namespace Olbrasoft.Dispatching.Dynamic
{
    public class AwesomeRequestHandler : IRequestHandler<AwesomeRequest, AwesomeResponse>
    {
        public Task<AwesomeResponse> HandleAsync(AwesomeRequest request, CancellationToken token)
        {
            return Task.FromResult(new AwesomeResponse());
        }
    }
}