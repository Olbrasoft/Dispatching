namespace Olbrasoft.Dispatching.Abstractions.Exceptions;

public class CreateHandlerException:InvalidOperationException
{

	public CreateHandlerException(Type exactType ) : base($"Failed to create {exactType} check it was registered.")
    {

	}
}