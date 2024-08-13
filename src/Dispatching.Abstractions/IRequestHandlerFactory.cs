namespace Olbrasoft.Dispatching;
public interface IRequestHandlerFactory
{
    THandler CreateRequestHandler<THandler>() where THandler : IHandler;
}
