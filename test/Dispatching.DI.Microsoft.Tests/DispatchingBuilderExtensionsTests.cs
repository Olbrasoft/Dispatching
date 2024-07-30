using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;
using Olbrasoft.Dispatching.DI.Microsoft.Common;
using Microsoft.Extensions.DependencyInjection;

namespace Olbrasoft.Dispatching.DI.Microsoft;
public class DispatchingBuilderExtensionsTests
{
    //DispatchingBuilderExtensions is public class
    [Fact]
    public void DispatchingBuilderExtensions_IsPublicClass()
    {
        // Arrange
        var type = typeof(DispatchingBuilderExtensions);

        // Act
        var result = type.IsPublic;

        // Assert
        Assert.True(result);
    }

    //assembly is Olbrasoft.Dispatching.Dynamic.DI.Microsoft
    [Fact]
    public void DispatchingBuilderExtensions_AssemblyIsOlbrasoftDispatchingDynamicDI()
    {
        // Arrange
        var type = typeof(DispatchingBuilderExtensions);

        // Act
        var result = type.Assembly.GetName().Name;

        // Assert
        Assert.Equal("Olbrasoft.Dispatching.DI.Microsoft", result);
    }

    //namespace is Olbrasoft.Dispatching.DI.Microsoft
    [Fact]
    public void DispatchingBuilderExtensions_NamespaceIsOlbrasoftDispatchingDynamicDI()
    {
        // Arrange
        var type = typeof(DispatchingBuilderExtensions);

        // Act
        var result = type.Namespace;

        // Assert
        Assert.Equal("Olbrasoft.Dispatching.DI.Microsoft", result);
    }

    //is static class
    [Fact]
    public void DispatchingBuilderExtensions_IsStaticClass()
    {
        // Arrange
        var type = typeof(DispatchingBuilderExtensions);

        // Act
        var result = type.IsAbstract && type.IsSealed;

        // Assert
        Assert.True(result);
    }

    //has method public static DispatchingBuilder UseDispatcherWithExecutor(this DispatchingBuilder builder)
    [Fact]
    public void DispatchingBuilderExtensions_UseDispatcherWithExecutor()
    {
        // Arrange
        var type = typeof(DispatchingBuilderExtensions);

        // Act
        var method = type.GetMethod("UseDispatcherWithExecutor");

        // Assert
        Assert.NotNull(method);
        Assert.True(method.IsPublic);
        Assert.True(method.IsStatic);
        Assert.Equal(typeof(DispatchingBuilder), method.ReturnType);
    }

    //method UseDispatcherWithExecutor register Executor <,> as Executor<,> and Dispatcher as IDispatcher
    [Fact]
    public void DispatchingBuilderExtensions_UseDispatcherWithExecutor_Registers_Executor_And_Dispatcher()
    {
        // Arrange
        var builder = new DispatchingBuilder(new ServiceCollection());

        // Act
        var result = DispatchingBuilderExtensions.UseDispatcherWithExecutor(builder);

        // Assert
        Assert.NotNull(result);
        Assert.Contains(builder.Services, s => s.ServiceType == typeof(Executor<,>) && s.ImplementationType == typeof(Executor<,>));
        Assert.Contains(builder.Services, s => s.ServiceType == typeof(IDispatcher) && s.ImplementationType == typeof(Dispatcher));
    }

    //UseDispatcherWithExecutor throws ArgumentNullException when builder is null
    [Fact]
    public void DispatchingBuilderExtensions_UseDispatcherWithExecutor_Throws_ArgumentNullException_When_Builder_Is_Null()
    {
        // Arrange
        DispatchingBuilder builder = null;

        // Act
        var exception = Assert.Throws<ArgumentNullException>(() => DispatchingBuilderExtensions.UseDispatcherWithExecutor(builder));

        // Assert
        Assert.Equal("builder", exception.ParamName);
    }
}
