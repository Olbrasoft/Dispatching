using Olbrasoft.Dispatching.DependencyInjection.Tests;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using Xunit;

namespace Olbrasoft.Extensions.Reflection
{
    public class AssembliesExtensionsTest
    {
        [Fact]
        public void Is_Static_Class()
        {
            var type = typeof(AssembliesExtensions);

            var result = type.IsStatic();

            //Assert
            Assert.True(result);
        }

        [Fact]
        public void RequestTypes()
        {
            //Arrange
            var assemblies = new List<Assembly>
            {
                typeof(AwesomeRequest1).Assembly
            };

            //Act
            var result = assemblies.RequestTypes();

            //Assert
            Assert.True(result.Count() == 2);
        }

        [Fact]
        public void RequestHandlerTypes()
        {
            //Arrange
            var assemblies = new List<Assembly>
            {
                typeof(AwesomeRequest1).Assembly
            };

            //Act
            var result = assemblies.RequestHandlerTypes();

            //Assert
            Assert.True(result.Count() == 1);
        }
    }
}