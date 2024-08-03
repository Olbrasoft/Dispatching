namespace Olbrasoft.Dispatching.Abstractions.Exceptions;

public class RequestHandlerNullException : ArgumentNullException
{
    public RequestHandlerNullException() : base("requestHandler")
    {
    }

    public RequestHandlerNullException(string paramRequestHandlerName) : base(paramRequestHandlerName)
    {
    }
}