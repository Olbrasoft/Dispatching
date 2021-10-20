﻿using Olbrasoft.Dispatching;

namespace Dispatching.Dynamic.Tests
{
    public class AwesomeRequest : Request<AwesomeResponse>
    {
        public AwesomeRequest(IDispatcher dispatcher) : base(dispatcher)
        {
        }
    }
}