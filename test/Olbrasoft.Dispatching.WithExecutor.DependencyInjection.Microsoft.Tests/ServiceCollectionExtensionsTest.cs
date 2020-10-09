using Microsoft.Extensions.DependencyInjection;
using Olbrasoft.Extensions;
using Xunit;

namespace Olbrasoft.Dispatching.WithExecutor.DependencyInjection.Microsoft
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
            Assert.True(services.Count == 5);
        }
    }
}