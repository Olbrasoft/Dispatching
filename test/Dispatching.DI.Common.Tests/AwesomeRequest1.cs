using Olbrasoft.Dispatching.Abstractions;

namespace Olbrasoft.Dispatching.DI.Common
{
    public class AwesomeRequest1 : Request<object>
    {
        public AwesomeRequest1(IRequestHandler<Request<object>, object> handler) : base(handler)
        {
        }
    }
}