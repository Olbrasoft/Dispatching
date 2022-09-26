using FluentAssertions;
using Microsoft.Extensions.DependencyInjection;
using Moq;
using Olbrasoft.Dispatching;
using System;
using System.Collections.Generic;
using System.Reflection;

namespace Olbrasoft.Extensions.DependencyInjection;
public class ServiceCollectionExtensionsTests
{
    [Fact]
    public void ServiceCollectionExtensions_CheckIsPublic_True()
    {
        // Arrange
        var type = typeof(ServiceCollectionExtensions);

        // Act
        var result = type.IsPublic;

        // Assert
        result.Should().BeTrue();
    }


    [Fact]
    public void ServiceCollectionExtensions_Assembly_SameAsConfiguration()
    {
        // Arrange
        var type = typeof(ServiceCollectionExtensions);
        var expectAssembly = typeof(DispatchingServiceConfiguration).Assembly;

        // Act
        var result = type.Assembly;

        // Assert
        result.Should().BeSameAs(expectAssembly);
    }

    [Fact]
    public void ServiceCollectionExtensions_CheckIsStatic_True()
    {
        // Arrange
        var type = typeof(ServiceCollectionExtensions);

        // Act
        var result = type.IsStatic();

        // Assert
        result.Should().BeTrue();

    }

    [Fact]
    public void AddDispatching_CallWithArgumentServices_NotThrowOfNotImplementationExeption()
    {
        // Arrange
        var services = new ServiceCollection();

        // Act
        Func<IServiceCollection> act = () => ServiceCollectionExtensions.AddDispatching(services, typeof(ServiceCollectionExtensions).Assembly);


        // Assert
        act.Should().NotThrow<NotImplementedException>();
    }

    [Fact]
    public void AddDispatchingWithArgumentServices_ReturnsResult_ReslutIsSameAsInputServices()
    {
        // Arrange
        IServiceCollection services = new ServiceCollection();

        // Act
        var result = ServiceCollectionExtensions.AddDispatching(services, typeof(ServiceCollectionExtensions).Assembly);


        // Assert
        result.Should().BeSameAs(services);

    }

    [Fact]
    public void AddDispatchingWithArgumentsAssembliesAndConfiguration_WhenArgumentAsssembliesIsNotAny_ThenThrowArgumentException()
    {
        // Arrange
        var services = new ServiceCollection();
        IEnumerable<Assembly> assemblies = new List<Assembly>();
        Action<DispatchingServiceConfiguration>? configuration = null;

        // Act
        var act = () => services.AddDispatching(assemblies, configuration);

        // Assert
        act.Should().Throw<ArgumentException>()
            .WithMessage("No assemblies found to scan. Supply at least one assembly to scan for handlers.");
    }

    [Fact]
    public void AddDispatchingWithArgumentsAssembliesAndConfiguration_WhenArgumentConfigurationIsNull_Invoke()
    {
        // Arrange
        var services = new ServiceCollection();
        IEnumerable<Assembly> assemblies = new List<Assembly> { typeof(ServiceCollectionExtensions).Assembly };
        var configurationMock = new Mock<Action<DispatchingServiceConfiguration>>();

        // Act
        services.AddDispatching(assemblies, configurationMock.Object);

        // Assert
        configurationMock.Verify(m => m.Invoke(It.IsAny<DispatchingServiceConfiguration>()), Times.Once);
    }

    [Fact]
    public void RegisterAwesomeBasicRequestHandlerAndBuildProvider_ProviderGetServiceOfIRequestHandlerOfAwesomeBasicRequestCommaString_ShouldBeReturnsAwesomeRequestHandler()
    {
        // Arrange
        var services = new ServiceCollection();
        IEnumerable<Assembly> assemblies = new List<Assembly> { typeof(AwesomeDispatcher).Assembly };
        services.AddDispatching(assemblies, null);
        var provider = services.BuildServiceProvider();

        // Act
        var result = provider.GetService<IRequestHandler<AwesomeBasicRequest, string>>();

        // Assert
        result.Should().NotBeNull().And.BeAssignableTo<AwesomeBasicRequestHandler>();

    }

    [Fact]
    public void AddDispatchingWithConfiguration_ConfigurationUseAwesomeDispatcherAndBuildProvider_ProviderGetServiceOfIDispatcherShouldBeReturnAwesomeDispatcher()
    {
        // Arrange
        var services = new ServiceCollection();
        IEnumerable<Assembly> assemblies = new List<Assembly> { typeof(AwesomeDispatcher).Assembly };
        services.AddDispatching(assemblies, cfg => cfg.Use<AwesomeDispatcher>());
        var provider = services.BuildServiceProvider();

        // Act
        var result = provider.GetService<IDispatcher>();

        // Assert
        result.Should().NotBeNull().And.BeAssignableTo<AwesomeDispatcher>();
    }

    [Fact]
    public void AddDispatchingWithConfigurationAndAssembly_BuildProviderAfterGetServiceOfIRequestHandlerOfAwesomeBasicRequestCommaString_ShouldBeAwesomeRequestHandler()
    {
        // Arrange
        var services = new ServiceCollection();
        services.AddDispatching(cfg => cfg.AsScopped(), typeof(AwesomeDispatcher).Assembly);
        var provider = services.BuildServiceProvider();

        // Act
        var result = provider.GetService<IRequestHandler<AwesomeBasicRequest, string>>();

        // Assert
        result.Should().NotBeNull().And.BeAssignableTo<AwesomeBasicRequestHandler>();

    }


    [Fact]
    public void AddDispatchingWithAsssemblyMarkers_BuildProviderAfterGetServiceOfIDispatcher_ShouldBeTypeDispatcher()
    {
        // Arrange
        var services = new ServiceCollection();
        services.AddDispatching(new List<Type> { typeof(AwesomeDispatcher) }, null);
        var provider = services.BuildServiceProvider();

        // Act
        var result = provider.GetService<IDispatcher>();

        // Assert
        result.Should().BeOfType<Dispatcher>();
    }

}
