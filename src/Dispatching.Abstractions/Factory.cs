using System.Collections.Generic;

namespace Olbrasoft.Dispatching;

/// <summary>
/// Factory method used to resolve Handler<see cref="IEnumerable{T}" />
/// </summary>
public delegate object Factory(Type type);