using Olbrasoft.Dispatching.Abstractions.Exceptions;
using Olbrasoft.Dispatching.Exceptions;

namespace Olbrasoft.Dispatching.Abstractions
{
    public abstract class BaseRequest<TResponse> : IRequest<TResponse>
    {
        public IDispatcher Dispatcher { get; }


        protected BaseRequest(IDispatcher dispatcher)
        {
            Dispatcher = dispatcher ?? throw new DispatcherNullException(nameof(dispatcher));
        }

        protected BaseRequest() { }

        public virtual async Task<TResponse> GetResponseAsync(CancellationToken token = default)
        {
            if (Dispatcher == null) throw new DispatcherNullException(nameof(Dispatcher));

            return await Dispatcher.DispatchAsync(this, token);
        }
    }

    public abstract class BaseRequest<TResponse, TRequest> : BaseRequest<TResponse> where TRequest : BaseRequest<TResponse,TRequest>, IRequest<TResponse>
    {
        public IRequestHandler<TRequest, TResponse> RequestHandler { get; }

        protected BaseRequest(IDispatcher dispatcher):base(dispatcher)
        {          
        }

        protected BaseRequest(IRequestHandler<TRequest, TResponse> requestHandler)
        {
            RequestHandler = requestHandler ?? throw new RequestHandlerNullException();
        }

        protected BaseRequest() { }

      public override async Task<TResponse> GetResponseAsync(CancellationToken token = default)
        {
            if (RequestHandler != null)  return await RequestHandler.HandleAsync((TRequest) this, token);

            return await base.GetResponseAsync(token);
        }
    }
}