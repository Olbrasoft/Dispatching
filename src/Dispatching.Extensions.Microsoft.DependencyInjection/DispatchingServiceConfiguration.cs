namespace Olbrasoft.Extensions.DependencyInjection;

public class DispatchingServiceConfiguration
{
    public ServiceLifetime Lifetime { get; private set; }
    public Type DispatcherType { get; private set; }

    public DispatchingServiceConfiguration()
    {
        DispatcherType = typeof(DynamicDispatcher);
        Lifetime = ServiceLifetime.Transient;
    }

    public DispatchingServiceConfiguration AsScopped()
    {

        Lifetime = ServiceLifetime.Scoped;
        return this;
    }

    public DispatchingServiceConfiguration AsSingleton()
    {
        Lifetime = ServiceLifetime.Singleton;
        return this;
    }

    public DispatchingServiceConfiguration AsTransient()
    {
        Lifetime = ServiceLifetime.Transient;
        return this;
    }

    public DispatchingServiceConfiguration Use<TDispatcher>() where TDispatcher : IDispatcher
    {
        DispatcherType = typeof(TDispatcher);
        return this;
    }
}
