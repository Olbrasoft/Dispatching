namespace Olbrasoft.Dispatching.DI.Grace
{
    public class AwesomeRequest : Request<object>
    {
        public AwesomeRequest(IRequestHandler<Request<object>, object> handler) : base(handler)
        {
        }
    }
}