
namespace Olbrasoft.Dispatching.Abstractions.Awesomes;

public class AwesomeRequestTwo : BaseRequest<string, AwesomeRequestTwo>
{
    public AwesomeRequestTwo(IDispatcher dispatcher) : base(dispatcher)
    {
    }

    public AwesomeRequestTwo() 
    {
    }


    public AwesomeRequestTwo(IRequestHandler<AwesomeRequestTwo, string> requestHandler) : base(requestHandler)
    {
    }
}