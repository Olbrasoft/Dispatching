using Olbrasoft.Dispatching;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Olbrasoft.Extensions.DependencyInjection;
public class AwesomeBasicRequestHandler : IRequestHandler<AwesomeBasicRequest, string>
{
    public Task<string> HandleAsync(AwesomeBasicRequest request, CancellationToken token)
    {
        throw new NotImplementedException();
    }
}
