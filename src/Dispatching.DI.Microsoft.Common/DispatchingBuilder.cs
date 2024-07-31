using System;
using Microsoft.Extensions.DependencyInjection;

namespace Olbrasoft.Dispatching.DI.Microsoft.Common;

public class DispatchingBuilder(IServiceCollection services)
{
    public IServiceCollection Services { get; } = services ?? throw new ArgumentNullException(nameof(services));
}