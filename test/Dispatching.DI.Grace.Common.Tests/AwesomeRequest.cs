using Olbrasoft.Dispatching.Abstractions;

namespace Olbrasoft.Dispatching.DI.Grace.Common
{
    public class AwesomeRequest : Request<object>
    {
        public AwesomeRequest(IRequestHandler<Request<object>, object> handler) : base(handler)
        {
        }
    }
}