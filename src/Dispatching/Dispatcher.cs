using System;

namespace Olbrasoft.Dispatching;

public class Dispatcher(Factory factory) : BaseDispatcher(factory)
{
    public override Task<TResponse> DispatchAsync<TResponse>(IRequest<TResponse> request, CancellationToken token = default)
    {
        if (request is not null)
        {
            var executor = GetHandler<IExecutor<TResponse>>(typeof(Executor<,>)
                    .MakeGenericType(request.GetType(), typeof(TResponse)));

            return executor.ExecuteAsync(request, token);
        }

        throw new ArgumentNullException(nameof(request));
    }
}   