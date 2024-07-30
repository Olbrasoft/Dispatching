using Microsoft.Extensions.DependencyInjection;
using Olbrasoft.Dispatching.DI.Microsoft.Common;
using System;
using Xunit;

namespace Olbrasoft.Dispatching.Dynamic.DI.Microsoft.Tests
{
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

        //assembly is Olbrasoft.Dispatching.Dynamic.DI.Microsoft
        [Fact]
        public void DispatchingBuilderExtensions_AssemblyIsOlbrasoftDispatchingDynamicDI()
        {
            // Arrange
            var type = typeof(DispatchingBuilderExtensions);

            // Act
            var result = type.Assembly.GetName().Name;

            // Assert
            Assert.Equal("Olbrasoft.Dispatching.Dynamic.DI.Microsoft", result);
        }

        //namespace is Olbrasoft.Dispatching.Dynamic.DI.Microsoft
        [Fact]
        public void DispatchingBuilderExtensions_NamespaceIsOlbrasoftDispatchingDynamicDI()
        {
            // Arrange
            var type = typeof(DispatchingBuilderExtensions);

            // Act
            var result = type.Namespace;

            // Assert
            Assert.Equal("Olbrasoft.Dispatching.Dynamic.DI.Microsoft", result);
        }

        //UseDynamicDispatcher is public static method
        [Fact]
        public void UseDynamicDispatcher_IsPublicStaticMethod()
        {
            // Arrange
            var method = typeof(DispatchingBuilderExtensions).GetMethod("UseDynamicDispatcher");

            // Act
            var result = method.IsPublic && method.IsStatic;

            // Assert
            Assert.True(result);
        }

        //UseDynamicDispatcher throw argument null exception when builder is null
        [Fact]
        public void UseDynamicDispatcher_ThrowArgumentNullException_WhenBuilderIsNull()
        {
            // Arrange
            DispatchingBuilder builder = null;

            // Act
            var exception = Assert.Throws<ArgumentNullException>(() => DispatchingBuilderExtensions.UseDynamicDispatcher(builder));

            // Assert
            Assert.Equal("builder", exception.ParamName);
        }

        //UseDynamicDispatcher return DispatchingBuilder
        [Fact]
        public void UseDynamicDispatcher_ReturnDispatchingBuilder()
        {
            // Arrange
            var builder = new DispatchingBuilder(new ServiceCollection());

            // Act
            var result = DispatchingBuilderExtensions.UseDynamicDispatcher(builder);

            // Assert
            Assert.IsType<DispatchingBuilder>(result);
        }

        //UseDynamicDispatcher register DynamicDispatcher as IDispatcher
        [Fact]
        public void UseDynamicDispatcher_RegisterDynamicDispatcherAsIDispatcher()
        {
            // Arrange
            var builder = new DispatchingBuilder(new ServiceCollection());


            // Act
            DispatchingBuilderExtensions.UseDynamicDispatcher(builder);

            // Assert
            Assert.Contains(builder.Services, s => s.ServiceType == typeof(IDispatcher) && s.ImplementationType == typeof(DynamicDispatcher));
        }

    }
}
