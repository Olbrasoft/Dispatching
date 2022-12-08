namespace Olbrasoft.Dispatching;

public class BaseRequest<TResponse> : IRequest<TResponse>
{
    public IDispatcher? Dispatcher { get; }

    public BaseRequest(IDispatcher dispatcher)
        => Dispatcher = dispatcher ?? throw new DispatcherNullException();

    protected BaseRequest()
    {
    }
}