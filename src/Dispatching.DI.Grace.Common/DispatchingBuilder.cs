using Grace.DependencyInjection;
using System;

namespace Olbrasoft.Dispatching.DI.Grace.Common
{
    public class DispatchingBuilder(IInjectionScope scope)
    {
        public IInjectionScope Scope { get; } = scope ?? throw new ArgumentNullException(nameof(scope));
    }
}