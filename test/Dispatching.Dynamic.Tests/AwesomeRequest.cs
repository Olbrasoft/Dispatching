namespace Olbrasoft.Dispatching.Dynamic
{
    public class AwesomeRequest : Request<AwesomeResponse>
    {
        public AwesomeRequest(IDispatcher dispatcher) : base(dispatcher)
        {
        }
    }
}