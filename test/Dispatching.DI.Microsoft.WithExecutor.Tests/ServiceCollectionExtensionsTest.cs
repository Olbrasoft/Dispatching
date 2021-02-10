using Microsoft.Extensions.DependencyInjection;
using Olbrasoft.Extensions;
using Olbrasoft.Extensions.DependencyInjection;
using Xunit;

namespace Olbrasoft.Dispatching.WithExecutor.DependencyInjection.Microsoft
{
    public class ServiceCollectionExtensionsTest
    {
        [Fact]
        public void Is_Static_Class()
        {
            //Arrange
            var type = typeof(DispatchingWithExecutorServiceCollectionExtensions);

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
    }
}