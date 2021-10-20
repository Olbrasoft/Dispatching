using System;
using Microsoft.Extensions.DependencyInjection;
using Olbrasoft.Extensions;
using Olbrasoft.Extensions.DependencyInjection;
using Xunit;

namespace Olbrasoft.Dispatching.DI.Microsoft
{
    public class ServiceCollectionExtensionsTest
    {
        [Fact]
        public void Is_Static_Class()
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
        public void AddDispatching_Registers_Three_Services()
        {
            //Arrange
            IServiceCollection services = new ServiceCollection();

            //Act
            services.AddDispatching();

            //Assert
            Assert.True(services.Count == 3);
        }

        [Fact]
        public void AddDispatching_Registers_Five_Services()
        {
            //Arrange
            IServiceCollection services = new ServiceCollection();

            //Act
            services.AddDispatching(typeof(AwesomeRequest).Assembly);

            //Assert
            Assert.True(services.Count == 4);
        }

        [Fact]
        public void AddDispatching_Throw_ArgumentNullException_When_Services_Is_Null()
        {
            //Arrange
            IServiceCollection services = null;

            //Act
            var ex = Assert.Throws<ArgumentNullException>(

                // ReSharper disable once AssignNullToNotNullAttribute
                () => services.AddDispatching(typeof(AwesomeRequest).Assembly));

            //Assert
            Assert.True(ex.Message is "Value cannot be null. (Parameter 'services')");
        }

        [Fact]
        public void AddDispatching_Throw_ArgumentNullException_When_Assemblies_Is_Null()
        {
            //Arrange
            IServiceCollection services = new ServiceCollection();
            //Act
            var ex = Assert.Throws<ArgumentNullException>(
                // ReSharper disable once AssignNullToNotNullAttribute
                () => services.AddDispatching(null));

            //Assert
            Assert.True(ex.Message is "Value cannot be null. (Parameter 'assemblies')");
        }
    }
}