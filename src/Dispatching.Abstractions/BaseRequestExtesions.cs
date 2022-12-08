namespace Olbrasoft.Dispatching.Abstractions;

public static class BaseRequestExtesions
{
    public static Task<object> ToResponseAsync(BaseRequest<object> request, CancellationToken token = default)
    {
        if (request is null) throw new RequestNullException();
               
        if(request.Dispatcher is not null)  return request.Dispatcher.DispatchAsync(request, token);

        throw new DispatcherNullException();
    }
}