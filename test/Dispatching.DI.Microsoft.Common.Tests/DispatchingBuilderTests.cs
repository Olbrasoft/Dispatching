using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace Olbrasoft.Dispatching.DI.Microsoft.Common
{
    public class DispatchingBuilderTests
    {
        //DispatchingBuilder is public class
        [Fact]
        public void DispatchingBuilder_IsPublicClass()
        {
            // Arrange
            var type = typeof(DispatchingBuilder);

            // Act
            var result = type.IsPublic;

            // Assert
            Assert.True(result);
        }

        //Constructor throw ArgumentNullException when services is null
        [Fact]
        public void DispatchingBuilder_Constructor_ThrowArgumentNullException_WhenServicesIsNull()
        {
            // Arrange
            IServiceCollection services = null;

            // Act
            var exception = Assert.Throws<ArgumentNullException>(() => new DispatchingBuilder(services));

            // Assert
            Assert.Equal("Value cannot be null. (Parameter 'services')", exception.Message);
        }
    }
}
