using System;
using System.Threading;
using System.Threading.Tasks;

namespace Olbrasoft.Dispatching;

public class DynamicDispatcher : DispatcherBase
{
    public DynamicDispatcher(Factory factory) : base(factory)
    {
    }

    public override Task<TResponse> DispatchAsync<TResponse>(IRequest<TResponse> request, CancellationToken token = default)
    {
        if (request is null)
            throw new ArgumentNullException(nameof(request));

        var handlerType = typeof(IRequestHandler<,>)
            .MakeGenericType(request.GetType(), typeof(TResponse));

        dynamic handler = GetHandler<IHandler>(handlerType);

        return handler.HandleAsync((dynamic)request, token);
    }
}