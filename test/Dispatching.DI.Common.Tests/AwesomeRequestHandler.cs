using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Olbrasoft.Dispatching.DI.Common
{
    public class AwesomeRequestHandler : IRequestHandler<AwesomeRequest1, object>
    {
        public Task<object> HandleAsync(AwesomeRequest1 request, CancellationToken token)
        {
            throw new NotImplementedException();
        }
    }
}
