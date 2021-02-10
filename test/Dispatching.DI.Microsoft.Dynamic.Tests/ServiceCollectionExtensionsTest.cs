using Microsoft.Extensions.DependencyInjection;
using Xunit;
using Olbrasoft.Extensions.DependencyInjection;

namespace Olbrasoft.Extensions.DependencyInjection
{
    public class ServiceCollectionExtensionsTest
    {
        [Fact]
        public void ServiceCollectionExtensions_Is_Static_Class()
        {
            //Arrange
            var type = typeof(DispatchingDynamicServiceCollectionExtensions);

            //Act
            var result = type.IsStatic();

            //Assert
            Assert.True(result);
        }

        [Fact]
        public void AddDispatching_Resturns_IServiceCollection()
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
    }
}