namespace Olbrasoft.Dispatching;

public class DynamicDispatcher : BaseDispatcher
{
    public DynamicDispatcher(CreateHandler createHandler) : base(createHandler)
    {
    }

    protected override Task<TResponse> SendAsync<TResponse>(IRequest<TResponse> request, CancellationToken token = default)
    {
        if (request is null)
            throw new RequestNullException();

        var handlerType = typeof(IRequestHandler<,>).MakeGenericType(request.GetType(), typeof(TResponse));

        dynamic handler = GetHandler<IHandler>(handlerType);

        return handler.HandleAsync((dynamic)request, token);
    }
}