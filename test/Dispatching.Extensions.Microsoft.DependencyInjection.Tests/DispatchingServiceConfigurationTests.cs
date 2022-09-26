using FluentAssertions;
using Microsoft.Extensions.DependencyInjection;
using Olbrasoft.Dispatching;
using System;
using Xunit;

namespace Olbrasoft.Extensions.DependencyInjection;
public class DispatchingServiceConfigurationTests
{
    [Fact]
    public void Is_Public()
    {
        //Arrange
        var type = typeof(DispatchingServiceConfiguration);

        //Act
        var result = type.IsPublic;

        //Assert
        result.Should().BeTrue();
    }

    [Fact]
    public void DispatchingServiceConfiguration_ConstructorSettingPropertyLifetime_LifetimeIsSettingsToTransient()
    {

        // Arrange
        var configuration = new DispatchingServiceConfiguration();

        // Act
        var lifetime = configuration.Lifetime;

        // Assert
        lifetime.Should().Be(ServiceLifetime.Transient);
    }


    [Fact]
    public void DispatchingServiceConfiguration_ConstructorSettingsPropertyDispatcherType_DispatcherTypeIsDispatcher()
    {
        // Arrange
        var configuration = new DispatchingServiceConfiguration();

        // Act
        var type = configuration.DispatcherType;

        // Assert
        type.Should().Be<Dispatcher>();
    }



    [Fact]
    public void Lifetime_TypeOf_ServiceLifetime()
    {
        // Arrange
        var configuration = new DispatchingServiceConfiguration();

        // Act
        object lifetime = configuration.Lifetime;

        // Assert
        lifetime.Should().BeAssignableTo<ServiceLifetime>();
    }


    [Fact]
    public void AsSingleton_SettingPropertyLifetime_LifetimeIsSingleton()
    {   // Arrange
        DispatchingServiceConfiguration configuration = new DispatchingServiceConfiguration();

        // Act
        configuration.AsSingleton();

        // Assert
        configuration.Lifetime.Should().Be(ServiceLifetime.Singleton);
    }


    [Fact]
    public void AsSinglton_SettingsPropertyLifetimeToSingleton_ReturnsDispatchingServiceConfiguration()
    {
        // Arrange
        var configuration = new DispatchingServiceConfiguration();

        // Act
        var result = configuration.AsSingleton();

        // Assert
        result.Should().BeAssignableTo<DispatchingServiceConfiguration>();

    }

    [Fact]
    public void AsScopped_SettingsProppertyLifetime_LifetimeShouldBeToScoped()
    {
        // Arrange
        var configuration = new DispatchingServiceConfiguration();

        // Act
        DispatchingServiceConfiguration result = configuration.AsScopped();

        // Assert
        result.Should().BeSameAs(configuration);
        result.Lifetime.Should().Be(ServiceLifetime.Scoped);
    }

    [Fact]
    public void AsTransient_SetLifetimeToTransient_ReturnsItself()
    {
        // Arrange
        var configuration = new DispatchingServiceConfiguration();
        configuration.AsScopped();

        // Act
        DispatchingServiceConfiguration result = configuration.AsTransient();

        // Assert
        configuration.Lifetime.Should().Be(ServiceLifetime.Transient);
        result.Should().BeSameAs(configuration);
    }

    [Fact]
    public void Use_SetDispatcherType_DispatcherTypeIsAwesomeDispatcher()
    {
        // Arrange
        var configuration = new DispatchingServiceConfiguration();

        // Act
        var act = () => configuration.Use<AwesomeDispatcher>();


        // Assert
        act.Should().NotThrow<NotImplementedException>();
        configuration.DispatcherType.Should().Be<AwesomeDispatcher>();

    }

    [Fact]
    public void Use_ReturnsValue_ReturnsItself()
    {
        // Arrange
        var configuration = new DispatchingServiceConfiguration();


        // Act
        var result = configuration.Use<AwesomeDispatcher>();

        // Assert
        result.Should().BeSameAs(configuration);

    }

}
