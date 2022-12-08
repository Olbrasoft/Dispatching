namespace Olbrasoft.Dispatching.Abstractions.Exceptions;

public class RequestNullException : ArgumentNullException
{
    public RequestNullException() : base("request")
    {
    }
}