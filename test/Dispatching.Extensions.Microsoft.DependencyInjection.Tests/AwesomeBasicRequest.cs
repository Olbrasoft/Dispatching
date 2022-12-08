using Olbrasoft.Dispatching;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Olbrasoft.Extensions.DependencyInjection;
public class AwesomeBasicRequest : IRequest<string>
{
    public Task<string> ToResponse(CancellationToken token)
    {
        throw new NotImplementedException();
    }
}
