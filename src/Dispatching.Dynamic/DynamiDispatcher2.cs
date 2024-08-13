using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace Olbrasoft.Dispatching;
public class DynamiDispatcher2 :BaseDispatcher2
{
    public DynamiDispatcher2(IRequestHandlerFactory requestHandlerFactory) : base(requestHandlerFactory)
    {
    }

    public override Task<TResponse> DispatchAsync<TResponse>(IRequest<TResponse> request, CancellationToken token = default)
    {
        if (request is not null)
        {
            var handlerType = typeof(IRequestHandler<,>)
                    .MakeGenericType(request.GetType(), typeof(TResponse));

            dynamic handler = GetHandler<IHandler>(handlerType);

            return handler.HandleAsync((dynamic)request, token);
        }

        throw new ArgumentNullException(nameof(request));
    }

}
