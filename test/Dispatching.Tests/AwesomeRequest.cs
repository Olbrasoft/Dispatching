using Olbrasoft.Dispatching;

namespace Dispatching.Dynamic.Tests
{
    public class AwesomeRequest : BaseRequest<AwesomeResponse>
    {
        public AwesomeRequest(IDispatcher dispatcher) : base(dispatcher)
        {
        }
    }
}