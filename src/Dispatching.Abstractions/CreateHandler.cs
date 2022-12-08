namespace Olbrasoft.Dispatching;

/// <summary>
/// Method used to resolve Handler
/// </summary>
/// <param name="exactType">A exactly type of handler that can handle the requested request</param>
/// <returns>A exactly type of handler like IHandler</returns>
public delegate IHandler CreateHandler(Type exactType);