using Grace.DependencyInjection;
using Olbrasoft.Extensions;
using System;
using Xunit;

namespace Olbrasoft.Dispatching.DI.Grace.Common
{
    public class InjectionScopeExtensionsTest
    {
        [Fact]
        public void IsAbstract()
        {
            //Arrange
            var type = typeof(InjectionScopeExtensions);

            //Act
            var result = type.IsStatic();

            //Assert
            Assert.True(result);
        }

        /// <summary>
        /// By default, it registers a function that corresponds to the factory delegate
        /// </summary>
        [Fact]
        public void Grace_Container_Default_Registered_Function_Corresponds_Factory()
        {
            //Arrange
            var container = CreateContainer();

            //Act
            Assert.True(container.TryLocate(typeof(Factory), out var factory));

            //Assert
            Assert.IsAssignableFrom<Factory>(factory);
        }

        [Fact]
        public void AddFactoryAndRequestHandlers_Returns_IInjectionScope()
        {
            //Arrange
            var container = CreateContainer();

            //Act
            var result = container.AddFactoryAndRequestHandlers();

            //Assert
            Assert.IsAssignableFrom<IInjectionScope>(result);
        }

        [Fact]
        public void AddFactoryAndRequestHandlers_Throw_ArgumentNullException_When_Scope_Is_Null()
        {
            //Arrange
            IInjectionScope scope = null;

            //Act
            // ReSharper disable once AssignNullToNotNullAttribute
            var ex = Assert.Throws<ArgumentNullException>(() => scope.AddFactoryAndRequestHandlers(typeof(AwesomeRequestHandler).Assembly));

            //Assert
            Assert.True(ex.Message is "Value cannot be null. (Parameter 'scope')");
        }

        [Fact]
        public void AddFactoryAndRequestHandlers_Throw_ArgumentNullException_When_Assemblies_Is_Null()
        {
            //Arrange
            var container = CreateContainer();

            //Act
            // ReSharper disable once AssignNullToNotNullAttribute
            var ex = Assert.Throws<ArgumentNullException>(() => container.AddFactoryAndRequestHandlers(null));

            //Assert
            Assert.True(ex.Message is "Value cannot be null. (Parameter 'assemblies')");
        }

        [Fact]
        public void AddFactoryRequestHandlers_Adds_One_Request()
        {
        }

        [Fact]
        public void AddFactoryRequestHandlers_Adds_One_Factory()
        {
            //Arrange
            var container = CreateContainer();

            //Act
            container.AddFactoryAndRequestHandlers(typeof(AwesomeRequest).Assembly);

            //Assert
            Assert.True(container.TryLocate(typeof(IRequestHandler<AwesomeRequest, object>), out var handler));
            //Assert
            Assert.True(container.TryLocate(typeof(Factory), out var factory));

            Assert.IsAssignableFrom<Factory>(factory);
        }

        private DependencyInjectionContainer CreateContainer()
        {
            return new DependencyInjectionContainer();
        }

        [Fact]
        public void AddRequestsAndRequestHandlers_Returns_IInjectionScope()
        {
            //Arrange
            var type = typeof(IInjectionScope);
            var container = CreateContainer();

            //Act
            var result = container.AddFactoryAndRequestHandlers();

            //Assert
            Assert.IsAssignableFrom(type, result);
        }

        [Fact]
        public void AddRequestHandlers_Adds_One_Request()
        {
            //Arrange
            var container = CreateContainer();

            //Act
            container.AddFactoryAndRequestHandlers(typeof(AwesomeRequest).Assembly);
            container.TryLocate(typeof(IRequestHandler<AwesomeRequest, object>), out var handler);

            //Assert
            Assert.IsAssignableFrom<AwesomeRequestHandler>(handler);
        }

        [Fact]
        public void AddRequestsAndRequestHandlers_If_Assemblies_Is_Null_Throw_ArgumentNullException()
        {
            //Arrange
            var container = CreateContainer();

            //Act
            // ReSharper disable once AssignNullToNotNullAttribute
            var ex = Assert.Throws<ArgumentNullException>(() => container.AddFactoryAndRequestHandlers(null));

            //Assert
            Assert.True(ex.Message is "Value cannot be null. (Parameter 'assemblies')");
        }

        [Fact]
        public void AddRequestHandlers_Throw_ArgumentNullException_When_Scope_Is_Null()
        {
            //Arrange
            IInjectionScope scope = null;

            //Act
            // ReSharper disable once AssignNullToNotNullAttribute
            var ex = Assert.Throws<ArgumentNullException>(() => scope.AddFactoryAndRequestHandlers(typeof(AwesomeRequestHandler).Assembly));

            //Assert
            Assert.True(ex.Message is "Value cannot be null. (Parameter 'scope')");
        }
    }
}