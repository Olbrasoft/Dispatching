using System;
using System.Threading;
using System.Threading.Tasks;
using Olbrasoft.Dispatching.Abstractions;

namespace Olbrasoft.Dispatching.DI.Microsoft
{
    public class AwesomeRequestHandler : IRequestHandler<AwesomeRequest, object>
    {
        public Task<object> HandleAsync(AwesomeRequest request, CancellationToken token)
        {
            throw new NotImplementedException();
        }
    }
}