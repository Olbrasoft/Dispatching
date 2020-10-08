using Microsoft.Extensions.DependencyInjection;
using Olbrasoft.Extensions;
using System.Linq;
using Xunit;

namespace Olbrasoft.Dispatching.DependencyInjection.Microsoft.Tests
{
    public class ServiceCollectionExtensionsTest
    {
        [Fact]
        public void IsAbsatract()
        {
            //Arrange
            var type = typeof(ServiceCollectionExtensions);

            //Act
            var result = type.IsStatic();

            //Assert
            Assert.True(result);
        }

        [Fact]
        public void AddRequestsAndRequestHandlers_Adds_One_Request()
        {
            //Arrange
            var services = CreateServices();

            //Act
            services.AddRequestsAndRequestHandlers(typeof(AwesomeRequest).Assembly);

            //Assert
            Assert.True(services.Count() == 2);
        }

        private static IServiceCollection CreateServices()
        {
            return new ServiceCollection();
        }

        [Fact]
        public void AddRequestHandlers()
        {
            //Arrange
            var services = CreateServices();

            //Act
            services.AddRequestHandlers(typeof(AwesomeRequestHandler).Assembly);

            //Assert
            Assert.True(services.Count == 1);
        }

        [Fact]
        public void AddFactoryAndRequestHandlers()
        {
            //Arrange
            var services = CreateServices();

            //Act
            services.AddFactoryAndRequestHandlers(typeof(AwesomeRequestHandler).Assembly);

            //Assert
            Assert.True(services.Count == 2);
        }
    }
}