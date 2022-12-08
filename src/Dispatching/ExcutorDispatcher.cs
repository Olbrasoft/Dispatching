namespace Olbrasoft.Dispatching;

public class ExcutorDispatcher : BaseDispatcher
{
    public ExcutorDispatcher(CreateHandler createHandler) : base(createHandler)
    {
    }

    protected override Task<TResponse> SendAsync<TResponse>(IRequest<TResponse> request, CancellationToken token = default)
    {
        if (request is null)
            throw new RequestNullException();

        var executor = GetHandler<IExecutor<TResponse>>(typeof(Executor<,>).MakeGenericType(request.GetType(), typeof(TResponse)));

        return executor.ExecuteAsync(request, token);
    }
}