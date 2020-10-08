using System;
using System.Threading;
using System.Threading.Tasks;

namespace Olbrasoft.Dispatching.DependencyInjection.Tests
{
    public class AwesomeRequestHandler1 : IRequestHandler<AwesomeRequest1, object>
    {
        public Task<object> HandleAsync(AwesomeRequest1 request, CancellationToken token)
        {
            throw new NotImplementedException();
        }
    }
}