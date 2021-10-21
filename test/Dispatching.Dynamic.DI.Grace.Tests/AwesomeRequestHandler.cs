using System;
using System.Threading;
using System.Threading.Tasks;

namespace Olbrasoft.Dispatching.Dynamic.DI.Grace
{
    public class AwesomeRequestHandler : IRequestHandler<AwesomeRequest, object>
    {
        public Task<object> HandleAsync(AwesomeRequest request, CancellationToken token)
        {
            return Task.FromResult(new object());
        }
    }
}