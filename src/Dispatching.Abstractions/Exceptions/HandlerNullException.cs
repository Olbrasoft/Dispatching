namespace Olbrasoft.Dispatching.Abstractions.Exceptions;

public class HandlerNullException : ArgumentNullException
{
	public HandlerNullException() : base("handler")
	{
	}
}