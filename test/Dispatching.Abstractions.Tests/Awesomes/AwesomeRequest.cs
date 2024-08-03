
namespace Olbrasoft.Dispatching.Abstractions.Awesomes;

public class AwesomeRequest : BaseRequest<string>
{
    public AwesomeRequest()
    {
    }

    public AwesomeRequest(IDispatcher dispatcher) : base(dispatcher)
    {
    }
}
