using System;
using System.Collections.Generic;
using System.Text;
using Xunit;
using Olbrasoft.Dispatching.DI.Grace.Common;
using System.Linq;
using Grace.DependencyInjection;

namespace Olbrasoft.Dispatching.DI.Grace.Tests
{
    public class DispatchingBuilderExtensionsTests
    {
        //DispatchingBuilderExtensions is public class
        [Fact]
        public void AddDispatching_Should_Be_Public()
        {
            // Arrange
            var type = typeof(DispatchingBuilderExtensions);

            // Act
            var result = type.IsPublic;

            // Assert
            Assert.True(result);
        }

        //Assembly is Olbrasoft.Dispatching.DI.Grace
        [Fact]
        public void AddDispatching_Should_Be_In_Olbrasoft_Dispatching_DI_Grace_Assembly()
        {
            // Arrange
            var type = typeof(DispatchingBuilderExtensions);

            // Act
            var result = type.Assembly.GetName().Name;

            // Assert
            Assert.Equal("Olbrasoft.Dispatching.DI.Grace", result);
        }

        //namespace is Olbrasoft.Dispatching.DI.Grace
        [Fact]
        public void AddDispatching_Should_Be_In_Olbrasoft_Dispatching_DI_Grace_Namespace()
        {
            // Arrange
            var type = typeof(DispatchingBuilderExtensions);

            // Act
            var result = type.Namespace;

            // Assert
            Assert.Equal("Olbrasoft.Dispatching.DI.Grace", result);
        }

        //is static class
        [Fact]
        public void AddDispatching_Should_Be_Static()
        {
            // Arrange
            var type = typeof(DispatchingBuilderExtensions);

            // Act
            var result = type.IsAbstract && type.IsSealed;

            // Assert
            Assert.True(result);
        }

        //has static method UseDispatcherWithExecutor
        [Fact]
        public void AddDispatching_Should_Has_UseDispatcherWithExecutor_Method()
        {
            // Arrange
            var type = typeof(DispatchingBuilderExtensions);

            // Act
            var result = type.GetMethod("UseDispatcherWithExecutor");

            // Assert
            Assert.NotNull(result);
        }

        //UseDispatcherWithExecutor is public static method
        [Fact]
        public void UseDispatcherWithExecutor_Should_Be_Public_Static()
        {
            // Arrange
            var method = typeof(DispatchingBuilderExtensions).GetMethod("UseDispatcherWithExecutor");

            // Act
            var result = method.IsPublic && method.IsStatic;

            // Assert
            Assert.True(result);

           
        }

        //UseDispatcherWithExecutor FIRST parameter is this DispatchingBuilder
        [Fact]
        public void UseDispatcherWithExecutor_First_Parameter_Should_Be_This_DispatchingBuilder()
        {
            // Arrange
            var method = typeof(DispatchingBuilderExtensions).GetMethod("UseDispatcherWithExecutor");

            // Act
            var result = method.GetParameters()[0].ParameterType;

            // Assert
            Assert.Equal(typeof(DispatchingBuilder), result);
        }

        //DispatchingBuilderExtensions.UseDispatcherWithExecutor is extension method on DispatchingBuilder
        [Fact]
        public void UseDispatcherWithExecutor_Should_Be_Extension_Method_On_DispatchingBuilder()
        {
            // Arrange
            var method = typeof(DispatchingBuilderExtensions).GetMethod("UseDispatcherWithExecutor");

            // Act
            var result = method.IsDefined(typeof(System.Runtime.CompilerServices.ExtensionAttribute), false);

            // Assert
            Assert.True(result);
        }

        //UseDispatcherWithExecutor return DispatchingBuilder
        [Fact]
        public void UseDispatcherWithExecutor_Should_Return_DispatchingBuilder()
        {
            // Arrange
            var method = typeof(DispatchingBuilderExtensions).GetMethod("UseDispatcherWithExecutor");

            // Act
            var result = method.ReturnType;

            // Assert
            Assert.Equal(typeof(DispatchingBuilder), result);
        }

        //UseDispatcherWithExecutor throw ArgumentNullException if DispatchingBuilder is null
        [Fact]
        public void UseDispatcherWithExecutor_Should_Throw_ArgumentNullException_If_DispatchingBuilder_Is_Null()
        {
            // Arrange
            DispatchingBuilder builder = null;

            // Act
#pragma warning disable IDE0039 // Use local function
            Action act = () => builder.UseDispatcherWithExecutor();
#pragma warning restore IDE0039 // Use local function

            // Assert
            Assert.Throws<ArgumentNullException>(act);
        }

        //UseDispatcherWithExecutor register Dispatcher as IDispatcher
        [Fact]
        public void UseDispatcherWithExecutor_Should_Register_Two_Services()
        {
            // Arrange
            var builder = new DispatchingBuilder(new DependencyInjectionContainer());

            // Act
            builder.UseDispatcherWithExecutor();
            var result = builder.Scope.Locate<IDispatcher>();

            // Assert
            Assert.IsType<Dispatcher>(result);
        }
    }
}
