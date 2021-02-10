using System;
using System.Threading;
using System.Threading.Tasks;

namespace Olbrasoft.Dispatching.DependencyInjection.Microsoft.Tests
{
    public class AwesomeRequestHandler : IRequestHandler<AwesomeRequest, object>
    {
        public Task<object> HandleAsync(AwesomeRequest request, CancellationToken token)
        {
            throw new NotImplementedException();
        }
    }
}