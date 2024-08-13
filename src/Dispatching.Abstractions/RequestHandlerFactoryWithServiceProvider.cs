using Microsoft.Extensions.DependencyInjection;

namespace Olbrasoft.Dispatching;
public class RequestHandlerFactoryWithServiceProvider(IServiceProvider serviceProvider) : IRequestHandlerFactory
{
    private readonly IServiceProvider _serviceProvider = serviceProvider;

    public THandler CreateRequestHandler<THandler>() where THandler : IHandler
    {
       return _serviceProvider.GetRequiredService<THandler>();
    }
}
