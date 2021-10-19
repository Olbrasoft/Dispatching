﻿using System;
using System.Threading;
using System.Threading.Tasks;

namespace Olbrasoft.Dispatching.DI.Grace.Common
{
    public class AwesomeRequestHandler : IRequestHandler<AwesomeRequest, object>
    {
        public Task<object> HandleAsync(AwesomeRequest request, CancellationToken token)
        {
            throw new NotImplementedException();
        }
    }
}