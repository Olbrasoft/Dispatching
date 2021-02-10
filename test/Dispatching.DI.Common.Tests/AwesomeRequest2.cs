namespace Olbrasoft.Dispatching.DependencyInjection.Tests
{
    public class AwesomeRequest2 : Request<object>
    {
        public AwesomeRequest2(IDispatcher dispatcher) : base(dispatcher)
        {
        }
    }
}