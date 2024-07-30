using Microsoft.Extensions.DependencyInjection;
using System;

namespace Olbrasoft.Dispatching.DI.Microsoft.Common;

public class DispatchingBuilder(IServiceCollection services)
{
    public IServiceCollection Services { get; set; } = services ?? throw new ArgumentNullException(nameof(services));
}