namespace Olbrasoft.Extensions.DependencyInjection;

public static class ServiceProviderExtensions
{
    /// <summary>
    /// Get service of type <paramref name="exactTypeHandler"/> from the <see cref="IServiceProvider"/>.
    /// </summary>
    /// <param name="provider">The <see cref="IServiceProvider"/> to retrieve the service object from.</param>
    /// <param name="exactTypeHandler">An object that specifies the type of service object to get.</param>
    /// <returns>A service object of type <paramref name="exactTypeHandler"/>.</returns>
    /// <exception cref="InvalidOperationException">There is no service of type <paramref name="exactTypeHandler"/>.</exception>
    public static IHandler GetHandler(this IServiceProvider provider, Type exactTypeHandler)
    {
        if (provider == null)
        {
            throw new ArgumentNullException(nameof(provider));
        }

        if (exactTypeHandler == null)
        {
            throw new ArgumentNullException(nameof(exactTypeHandler));
        }

        if (provider is ISupportRequiredService requiredServiceSupportingProvider)
        {
            return (IHandler)requiredServiceSupportingProvider.GetRequiredService(exactTypeHandler);
        }

        object? service = provider.GetService(exactTypeHandler);

        return service is null ? throw new InvalidOperationException( $"{nameof(exactTypeHandler)}: {exactTypeHandler} not found") : (IHandler)service;
    }
}