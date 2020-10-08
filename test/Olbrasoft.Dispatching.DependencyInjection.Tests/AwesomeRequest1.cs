using Olbrasoft.Dispatching.Common;

namespace Olbrasoft.Dispatching.DependencyInjection.Tests
{
    public class AwesomeRequest1 : Request<object>
    {
        public AwesomeRequest1(IRequestHandler<Request<object>, object> handler) : base(handler)
        {
        }
    }
}