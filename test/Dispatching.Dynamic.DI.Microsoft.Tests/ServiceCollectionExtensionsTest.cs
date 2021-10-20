using System;
using Microsoft.Extensions.DependencyInjection;

using Olbrasoft.Extensions;
using Olbrasoft.Extensions.DependencyInjection;
using Xunit;

namespace Olbrasoft.Dispatching.Dynamic.DI.Microsoft
{
    public class ServiceCollectionExtensionsTest
    {
        [Fact]
        public void ServiceCollectionExtensions_Is_Static_Class()
        {
            //Arrange
            var type = typeof(ServiceCollectionExtensions);

            //Act
            var result = type.IsStatic();

            //Assert
            Assert.True(result);
        }

        [Fact]
        public void AddDispatching_Returns_IServiceCollection()
        {
            //Arrange
            var services = new ServiceCollection();

            //Act
            var result = services.AddDispatching();

            //Assert
            Assert.IsAssignableFrom<IServiceCollection>(result);
        }

        [Fact]
        public void AddDispatching()
        {
            //Arrange
            var services = new ServiceCollection();

            //Act
            services.AddDispatching();

            //Assert
            Assert.True(services.Count == 2);
        }

        [Fact]
        public void AddDispatching_Throw_ArgumentNullException_When_Services_Is_Null()
        {
            //Arrange
            IServiceCollection service = null;

            //Act
            // ReSharper disable once AssignNullToNotNullAttribute
            var ex = Assert.Throws<ArgumentNullException>((() => service.AddDispatching()));

            //Assert
            Assert.True(ex.Message is "Value cannot be null. (Parameter 'services')");
        }

        [Fact]
        public void AddDispatching_Throw_ArgumentNullException_When_Assemblies_Is_Null()
        {
            //Arrange
            var services = new ServiceCollection();

            //Act
            // ReSharper disable once AssignNullToNotNullAttribute
            var ex = Assert.Throws<ArgumentNullException>((() => services.AddDispatching(null)));

            Assert.True(ex.Message is "Value cannot be null. (Parameter 'assemblies')");

            //Assert
        }
    }
}