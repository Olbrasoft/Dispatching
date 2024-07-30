namespace Olbrasoft.Dispatching;

public abstract class DispatcherBase(Factory factory) : IDispatcher
{
    private readonly Factory _factory = factory ?? throw new ArgumentNullException(nameof(factory));

    public abstract Task<TResponse> DispatchAsync<TResponse>(IRequest<TResponse> request, CancellationToken token = default);

    protected THandler GetHandler<THandler>(Type type) where THandler : IHandler
    {
        if (type is not null)
        {
            var adeptHandler = _factory(type) ?? throw new InvalidOperationException($"Could not create handler for type {type}");

            return (THandler)adeptHandler;
        }

        throw new ArgumentNullException(nameof(type));
    }
}