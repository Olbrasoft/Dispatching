using Microsoft.Extensions.DependencyInjection;
using Olbrasoft.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using Xunit;
using static Xunit.Assert;

namespace Olbrasoft.Dispatching.DI.Microsoft.Common
{
    public class ServiceCollectionExtensionsTest
    {
        [Fact]
        public void IsAbstract()
        {
            //Arrange
            var type = typeof(ServiceCollectionExtensions);

            //Act
            var result = type.IsStatic();

            //Assert
            True(result);
        }

        [Fact]
        public void AddRequestsAndRequestHandlers_Returns_IServiceCollection()
        {
            //Arrange
            var type = typeof(IServiceCollection);
            var services = CreateServices;

            //Act
            var result = services.AddRequestsAndRequestHandlers();

            //Assert
            IsAssignableFrom(type, result);
        }

        [Fact]
        public void AddRequestsAndRequestHandlers_Adds_One_Request()
        {
            //Arrange
            var services = CreateServices;

            //Act
            services.AddRequestsAndRequestHandlers(typeof(AwesomeRequest).Assembly);

            //Assert
            Assert.Equal(2, services.Count);
        }

        [Fact]
        public void Microsoft_DI_Container_Default_No_Registered_Function_Corresponded_Factory()
        {
            //Arrange
            var services = CreateServices;

            //Act
            //services.AddFactoryAndRequestHandlers(typeof(AwesomeRequestHandler).Assembly);
            var serviceProvider = services.BuildServiceProvider();
            var factory = serviceProvider.GetService(typeof(Factory));

            //Assert
            Assert.True(factory is null);
        }

        private static IServiceCollection CreateServices => new ServiceCollection();

        [Fact]
        public void AddRequestHandlers()
        {
            //Arrange
            var services = CreateServices;

            //Act
            services.AddRequestHandlers(typeof(AwesomeRequestHandler).Assembly);

            //Assert
            Assert.Single(services);
        }

        [Fact]
        public void AddRequestHandlers_Returns_IServiceCollection()
        {
            //Arrange
            var type = typeof(IServiceCollection);
            var services = CreateServices;

            //Act
            var result = services.AddRequestHandlers();

            //Assert
            IsAssignableFrom(type, result);
        }

        [Fact]
        public void AddFactoryAndRequestHandlers()
        {
            //Arrange
            var services = CreateServices;

            //Act
            services.AddFactoryAndRequestHandlers(typeof(AwesomeRequestHandler).Assembly);

            //Assert
#pragma warning disable xUnit2024 // Do not use boolean asserts for simple equality tests
            True(services.Count == 2);
#pragma warning restore xUnit2024 // Do not use boolean asserts for simple equality tests
        }

        [Fact]
        public void AddFactoryAndRequestHandlers_Returns_IServiceCollection()
        {
            //Arrange
            var services = CreateServices;

            //Act
            var result = services.AddFactoryAndRequestHandlers();

            //Assert
            IsAssignableFrom<IServiceCollection>(result);
        }

        [Fact]
        public void AddRequestsAndRequestHandlers_If_Services_Is_Null_Throw_ArgumentNullException()
        {
            //Arrange
            IServiceCollection services = null;

            //Assert
            Throws<ArgumentNullException>(() =>
                // ReSharper disable once AssignNullToNotNullAttribute
                services.AddRequestsAndRequestHandlers([]));
        }

        [Fact]
        public void AddRequestsAndRequestHandlers_If_Assemblies_Is_Null_Throw_ArgumentNullException()
        {
            //Arrange
            var services = CreateServices;

            //Act
            // ReSharper disable once AssignNullToNotNullAttribute
            var ex = Assert.Throws<ArgumentNullException>(() => services.AddRequestsAndRequestHandlers(null));

            //Assert
            True(ex.Message is "Value cannot be null. (Parameter 'assemblies')");
        }

        [Fact]
        public void AddRequestHandlers_If_Services_Is_Null_Throw_ArgumentNullException()
        {
            //Arrange
            IServiceCollection services = null;

            //Act
            // ReSharper disable once AssignNullToNotNullAttribute
            var ex = Assert.Throws<ArgumentNullException>(() => services.AddRequestHandlers(typeof(AwesomeRequestHandler).Assembly));

            //Assert
            True(ex.Message is "Value cannot be null. (Parameter 'services')");
        }

        [Fact]
        public void AddRequestHandlers_If_assemblies_Is_Null_Throw_ArgumentNullException()
        {
            //Arrange
            var services = CreateServices;

            //Act
            // ReSharper disable once AssignNullToNotNullAttribute
            var ex = Assert.Throws<ArgumentNullException>(() => services.AddRequestHandlers(null));

            //Assert
            True(ex.Message is "Value cannot be null. (Parameter 'assemblies')");
        }

        [Fact]
        public void AddFactoryAndRequestHandlers_Throw_ArgumentNullException_When_Services_Is_Null()
        {
            //Arrange
            IServiceCollection services = null;

            //Act
            // ReSharper disable once AssignNullToNotNullAttribute
            var ex = Assert.Throws<ArgumentNullException>(() => services.AddFactoryAndRequestHandlers(typeof(AwesomeRequestHandler).Assembly));

            //Assert
            True(ex.Message is "Value cannot be null. (Parameter 'services')");
        }

        [Fact]
        public void AddFactoryAndRequestHandlers_Throw_ArgumentNullException_When_Assemblies_Is_Null()
        {
            //Arrange
            var services = CreateServices;

            //Act
            // ReSharper disable once AssignNullToNotNullAttribute
            var ex = Assert.Throws<ArgumentNullException>(() => services.AddFactoryAndRequestHandlers(null));

            //Assert
            True(ex.Message is "Value cannot be null. (Parameter 'assemblies')");
        }
    }
}