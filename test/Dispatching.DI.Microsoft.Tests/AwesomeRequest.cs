using Olbrasoft.Dispatching.Abstractions;

namespace Olbrasoft.Dispatching.DI.Microsoft
{
    public class AwesomeRequest : Request<object>
    {
        public AwesomeRequest(IRequestHandler<Request<object>, object> handler) : base(handler)
        {
        }
    }
}