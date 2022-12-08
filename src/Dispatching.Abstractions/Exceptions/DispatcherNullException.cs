namespace Olbrasoft.Dispatching.Abstractions.Exceptions;

public class DispatcherNullException : ArgumentNullException
{
	public DispatcherNullException() : base("dispatcher")
	{

	}
}