using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using FluentAssertions;
using Olbrasoft.Extensions;
using Olbrasoft.Extensions.DependencyInjection;
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
            result.Should().HaveCount(3);
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
            Assert.True(result.Count() == 2);
        }

        [Fact]
        public void RequestTypes_If_Assemblies_Is_Null_Throw_ArgumentNullException()
        {
            //Arrange
#pragma warning disable CS8600 // Converting null literal or possible null value to non-nullable type.
            IEnumerable<Assembly> assemblies = null;
#pragma warning restore CS8600 // Converting null literal or possible null value to non-nullable type.

            //Assert
            // ReSharper disable once AssignNullToNotNullAttribute
#pragma warning disable CS8604 // Possible null reference argument.
            Assert.Throws<ArgumentNullException>(() => assemblies.RequestTypes());
#pragma warning restore CS8604 // Possible null reference argument.
        }

        [Fact]
        public void RequestHandlerTypes_If_Assemblies_Is_Null_Throw_ArgumentNullException()
        {
            //Arrange
#pragma warning disable CS8600 // Converting null literal or possible null value to non-nullable type.
            IEnumerable<Assembly> assemblies = null;
#pragma warning restore CS8600 // Converting null literal or possible null value to non-nullable type.

            //Assert
            // ReSharper disable once AssignNullToNotNullAttribute
#pragma warning disable CS8604 // Possible null reference argument.
            Assert.Throws<ArgumentNullException>(() => assemblies.RequestHandlerTypes());
#pragma warning restore CS8604 // Possible null reference argument.
        }
    }
}