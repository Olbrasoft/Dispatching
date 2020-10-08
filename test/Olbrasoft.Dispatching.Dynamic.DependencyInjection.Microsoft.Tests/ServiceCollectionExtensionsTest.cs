using Microsoft.Extensions.DependencyInjection;
using Olbrasoft.Extensions;
using System;
using Xunit;

namespace Olbrasoft.Dispatching.Dynamic.DependencyInjection.Microsoft.Tests
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