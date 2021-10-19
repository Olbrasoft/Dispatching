using System;
using System.Collections.Generic;

namespace Olbrasoft.Dispatching
{
    /// <summary>
    /// Factory method used to resolve all services. For multiple instances, it will resolve against <see cref="IEnumerable{T}" />
    /// </summary>
    public delegate object Factory(Type type);
}