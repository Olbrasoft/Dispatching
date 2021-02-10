namespace Olbrasoft.Dispatching.WithExecutor.DependencyInjection.Microsoft
{
    public class AwesomeRequest : Request<object>
    {
        public AwesomeRequest(IRequestHandler<Request<object>, object> handler) : base(handler)
        {
        }
    }
}