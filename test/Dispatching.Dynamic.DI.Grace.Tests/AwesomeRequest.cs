﻿using Olbrasoft.Dispatching.Abstractions;

namespace Olbrasoft.Dispatching.Dynamic.DI.Grace
{
    public class AwesomeRequest : Request<object>
    {
        public AwesomeRequest(IRequestHandler<Request<object>, object> handler) : base(handler)
        {
        }
    }
}