using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Concurrent;

namespace Olbrasoft.Dispatching;

public class Dispatcher : BaseDispatcher
{
    private static readonly ConcurrentDictionary<Type, IHandler> _requestHandlers = new();
    private readonly IRequestHandlerFactory _factory;
  
    public Dispatcher(  IRequestHandlerFactory factory)
    {
      
        _factory = factory;
    }

    public override Task<TResponse> DispatchAsync<TResponse>(IRequest<TResponse> request, CancellationToken token = default)
    {
        if (request is not null)
        {
            //var executor = (IExecutor<TResponse>) _requestHandlers.GetOrAdd(request.GetType(), GetHandler<IExecutor<TResponse>>(typeof(Executor<,>)
            //         .MakeGenericType(request.GetType(), typeof(TResponse))));

            //return executor.ExecuteAsync(request, token);

            var handler = (RequestHandlerWrapper<TResponse>)_requestHandlers.GetOrAdd(request.GetType(), static requestType =>
            {
                var wrapperType = typeof(RequestHandlerWrapperImpl<,>).MakeGenericType(requestType, typeof(TResponse));
                var wrapper = Activator.CreateInstance(wrapperType) ?? throw new InvalidOperationException($"Could not create wrapper type for {requestType}");
                return (IHandler)wrapper;
            });


           return handler.HandleAsync(request, _factory, token);
        }

        throw new ArgumentNullException(nameof(request));
    }
}



public abstract class RequestHandlerWrapper<TResponse>  : IHandler
{
    public abstract Task<TResponse> HandleAsync(IRequest<TResponse> request, IRequestHandlerFactory factory,
        CancellationToken cancellationToken);
}

public class RequestHandlerWrapperImpl<TRequest, TResponse> : RequestHandlerWrapper<TResponse>
    where TRequest : IRequest<TResponse>
{
       
    public override Task<TResponse> HandleAsync(IRequest<TResponse> request, IRequestHandlerFactory factory, CancellationToken cancellationToken)
    {
        return factory.CreateRequestHandler<IRequestHandler<TRequest, TResponse>>()
            .HandleAsync((TRequest)request, cancellationToken);
    }

  
}