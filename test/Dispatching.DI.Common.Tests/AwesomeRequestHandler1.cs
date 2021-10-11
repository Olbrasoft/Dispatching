﻿using System;
using System.Threading;
using System.Threading.Tasks;
using Olbrasoft.Dispatching.Abstractions;

namespace Olbrasoft.Dispatching.DI.Common
{
    public class AwesomeRequestHandler1 : IRequestHandler<AwesomeRequest1, object>
    {
        public Task<object> HandleAsync(AwesomeRequest1 request, CancellationToken token)
        {
            throw new NotImplementedException();
        }
    }
}