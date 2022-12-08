using FluentAssertions;
using Olbrasoft.Dispatching;
using Olbrasoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Dispatching.Dynamic.Tests
{
    public class ServiceProviderExtensionsTests
    {
        [Fact]
        public void TypeOf_ServiceProviderExtensions_IsPublicShouldBeTrue()
        {
            // Arrange
            var sut = typeof(ServiceProviderExtensions);
            // Act
            var result = sut.IsPublic;
            // Assert
            result.Should().BeTrue();
        }

        [Fact]
        public void TypeOf_ServiceProviderExtensions_AssemblySholdBySameAsTypeOfIHandlerAssembly()
        {
            // Arrange
            var expected = typeof(DispatchingServiceConfiguration).Assembly;

            // Act
            var result = typeof(ServiceProviderExtensions).Assembly;

            // Assert
            result.Should().BeSameAs(expected);

        }
    }
}