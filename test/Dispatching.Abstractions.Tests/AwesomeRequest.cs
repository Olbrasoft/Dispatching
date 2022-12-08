namespace Olbrasoft.Dispatching.Abstractions;
public class AwesomeRequest : BaseRequest<object>
{
     

    public AwesomeRequest(IDispatcher dispatcher) : base(dispatcher)
    {
    }

    public AwesomeRequest()
    {
    }
}
