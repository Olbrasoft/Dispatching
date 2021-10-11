using Olbrasoft.Dispatching.Abstractions;

namespace Olbrasoft.Dispatching.DI.Common
{
    public class AwesomeRequest2 : Request<object>
    {
        public AwesomeRequest2(IDispatcher dispatcher) : base(dispatcher)
        {
        }
    }
}