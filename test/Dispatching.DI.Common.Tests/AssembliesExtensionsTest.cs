using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using Olbrasoft.Extensions;
using Olbrasoft.Extensions.Reflection;
using Xunit;

namespace Olbrasoft.Dispatching.DI.Common
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

        [Fact]
        public void RequestTypes_If_Assemblies_Is_Null_Throw_ArgumentNullException()
        {
            //Arrange
            IEnumerable<Assembly> assemblies = null;

            //Assert
            // ReSharper disable once AssignNullToNotNullAttribute
            Assert.Throws<ArgumentNullException>(() => assemblies.RequestTypes());
        }

        [Fact]
        public void RequestHandlerTypes_If_Assemblies_Is_Null_Throw_ArgumentNullException()
        {
            //Arrange
            IEnumerable<Assembly> assemblies = null;

            //Assert
            // ReSharper disable once AssignNullToNotNullAttribute
            Assert.Throws<ArgumentNullException>(() => assemblies.RequestHandlerTypes());
        }
    }
}