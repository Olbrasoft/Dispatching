using System;
using Grace.DependencyInjection;
using Olbrasoft.Dispatching.Abstractions;
using Olbrasoft.Extensions;
using Xunit;

namespace Olbrasoft.Dispatching.Dynamic.DI.Grace
{
    public class InjectionScopeExtensionsTest
    {
        [Fact]
        public void Is_Static_Class()
        {
            //Arrange
            var type = typeof(InjectionScopeExtensions);

            //Act
            var result = type.IsStatic();

            //Assert
            Assert.True(result);
        }

        [Fact]
        public void AddDispatching_Returns_InjectionScope()
        {
            //Arrange
            var scope = CreateScope();

            ////Act
            var result = scope.AddDispatching();

            ////Assert
            Assert.IsAssignableFrom<IInjectionScope>(result);
        }

        [Fact]
        public void AddDispatching_Throw_ArgumentNullException_When_Services_Is_Null()
        {
            //Arrange
            IInjectionScope scope = null;

            //Act
            var ex = Assert.Throws<ArgumentNullException>(

                // ReSharper disable once AssignNullToNotNullAttribute
                () => scope.AddDispatching(typeof(AwesomeRequest).Assembly));

            //Assert
            Assert.True(ex.Message is "Value cannot be null. (Parameter 'scope')");
        }

        [Fact]
        public void AddDispatching_Throw_ArgumentNullException_When_Assemblies_Is_Null()
        {
            //Arrange
            IInjectionScope services = CreateScope();
            //Act
            var ex = Assert.Throws<ArgumentNullException>(
                // ReSharper disable once AssignNullToNotNullAttribute
                () => services.AddDispatching(null));

            //Assert
            Assert.True(ex.Message is "Value cannot be null. (Parameter 'assemblies')");
        }

        [Fact]
        public void AddDispatching_Registered_Dispatcher()
        {
            //Arrange
            IInjectionScope scope = CreateScope();

            //Act
            scope.AddDispatching(typeof(AwesomeRequest).Assembly);
            var dispatcher = scope.Locate<IDispatcher>();

            //Assert
            Assert.IsAssignableFrom<DynamicDispatcher>(dispatcher);
        }

        [Fact]
        public void AddDispatching_Registered_Handlers()
        {
            //Arrange
            IInjectionScope scope = CreateScope();

            //Act
            scope.AddDispatching(typeof(AwesomeRequest).Assembly);
            var handler = scope.Locate<IRequestHandler<AwesomeRequest, object>>();

            //Assert
            Assert.IsAssignableFrom<AwesomeRequestHandler>(handler);
        }

        private IInjectionScope CreateScope()
        {
            return new DependencyInjectionContainer();
        }
    }
}