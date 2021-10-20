namespace Olbrasoft.Dispatching.DI.Microsoft.Common
{
    public class AwesomeRequest : Request<object>
    {
        public AwesomeRequest(IRequestHandler<Request<object>, object> handler) : base(handler)
        {
        }
    }
}