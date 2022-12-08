using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Olbrasoft.Dispatching.Abstractions;
public class AwesomeRequestHandler : IRequestHandler<AwesomeRequest, object>
{
    public Task<object> HandleAsync(AwesomeRequest request, CancellationToken token)
    {
        throw new NotImplementedException();
    }
}
