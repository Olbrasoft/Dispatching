﻿namespace Olbrasoft.Dispatching.DI.Common
{
    public class AwesomeRequest1 : BaseRequest<object>
    {
        public AwesomeRequest1(IRequestHandler<BaseRequest<object>, object> handler) : base(handler)
        {
        }
    }
}