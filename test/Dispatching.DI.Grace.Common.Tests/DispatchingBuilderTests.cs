using Grace.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace Olbrasoft.Dispatching.DI.Grace.Common
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

        //assembly is Olbrasoft.Dispatching.Dynamic.DI.Grace
        [Fact]
        public void DispatchingBuilder_AssemblyIsOlbrasoftDispatchingDynamicDI()
        {
            // Arrange
            var type = typeof(DispatchingBuilder);

            // Act
            var result = type.Assembly.GetName().Name;

            // Assert
            Assert.Equal("Olbrasoft.Dispatching.DI.Grace.Common", result);
        }

        //namespace is Olbrasoft.Dispatching.DI.Grace.Common
        [Fact]
        public void DispatchingBuilder_NamespaceIsOlbrasoftDispatchingDynamicDI()
        {
            // Arrange
            var type = typeof(DispatchingBuilder);

            // Act
            var result = type.Namespace;

            // Assert
            Assert.Equal("Olbrasoft.Dispatching.DI.Grace.Common", result);
        }

        //has constructor with IInjectionScope scope parameter
        [Fact]
        public void DispatchingBuilder_HasConstructorWithIInjectionScopeParameter()
        {
            // Arrange
            var type = typeof(DispatchingBuilder);

            // Act
            var constructor = type.GetConstructor(new[] { typeof(IInjectionScope) });

            // Assert
            Assert.NotNull(constructor);
        }

        //constructor throw ArgumentNullException when scope is null
        [Fact]
            public void DispatchingBuilder_Constructor_ThrowArgumentNullException_WhenScopeIsNull()
        {
            // Arrange
            IInjectionScope scope = null;

            // Act
            var exception = Assert.Throws<ArgumentNullException>(() => new DispatchingBuilder(scope));

            // Assert
            Assert.Equal("Value cannot be null. (Parameter 'scope')", exception.Message);
          }



        //has property Scope
        [Fact]
        public void DispatchingBuilder_HasPropertyScope()
        {
            // Arrange
            var type = typeof(DispatchingBuilder);

            // Act
            var property = type.GetProperty("Scope");

            // Assert
            Assert.NotNull(property);
        }

        //property Scope is read-only
        [Fact]
        public void DispatchingBuilder_PropertyScope_IsReadOnly()
        {
            // Arrange
            var type = typeof(DispatchingBuilder);
            var property = type.GetProperty("Scope");

            // Act
            var result = property.GetSetMethod(true) == null;

            // Assert
            Assert.True(result);
        }





    }
}
