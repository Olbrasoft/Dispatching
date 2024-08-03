namespace Olbrasoft.Dispatching.Exceptions;

public class DispatcherNullException : ArgumentNullException
{
    public DispatcherNullException() : base("dispatcher")
    {

    }

    public DispatcherNullException(string paramDispatcherName) : base(paramDispatcherName)
    {

    }
}