using Grace.DependencyInjection;
using Olbrasoft.Extensions;
using System;
using Xunit;


namespace Olbrasoft.Dispatching.DI.Grace.Common
{
    public class InjectionScopeExtensionsTest
    {
        [Fact]
        public void IsAbstract()
        {
            //Arrange
            var type = typeof(InjectionScopeExtensions);

            //Act
            var result = type.IsStatic();

            //Assert
            Assert.True(result);
        }

        /// <summary>
        /// By default, it registers a function that corresponds to the factory delegate
        /// </summary>
        [Fact]
        public void Grace_Container_Default_Registered_Function_Corresponds_Factory()
        {
            //Arrange
            var container = CreateContainer();

            //Act
            Assert.True(container.TryLocate(typeof(Factory), out var factory));

            //Assert
            Assert.IsAssignableFrom<Factory>(factory);
        }

      

 

        private DependencyInjectionContainer CreateContainer()
        {
            return new DependencyInjectionContainer();
        }


        //InjectionScopeExtensions has static method AddDispatching
        [Fact]
        public void AddDispatching()
        {
            //Arrange
            var type = typeof(InjectionScopeExtensions);

            //Act
            var result = type.GetMethod("AddDispatching");

            //Assert
            Assert.NotNull(result);
        }


        //AddDispatching has parameter this IInjectionScope scope
        [Fact]
        public void AddDispatching_Has_Parameter_This_IInjectionScope_Scope()
        {
            //Arrange
            var type = typeof(InjectionScopeExtensions);
            var method = type.GetMethod("AddDispatching");

            //Act
            var parameters = method.GetParameters();

            //Assert
            Assert.True(parameters[0].ParameterType == typeof(IInjectionScope));
        }


        //AddDispatching has extension method AddDispatching (this IInjectionScope scope)
        [Fact]
        public void AddDispatching_Has_Extension_Method_AddDispatching_This_IInjectionScope()
        {
            //Arrange
            var type = typeof(InjectionScopeExtensions);
            var method = type.GetMethod("AddDispatching");

            //Act
            var result = method.IsDefined(typeof(System.Runtime.CompilerServices.ExtensionAttribute), false);

            //Assert
            Assert.True(result);
        }
               
        //AddDispatching return DispatchingBuilder
        [Fact]
        public void AddDispatching_Returns_DispatchingBuilder()
        {
            //Arrange
            var container = CreateContainer();

            //Act
            var result = container.AddDispatching(typeof(AwesomeRequest).Assembly);

            //Assert
            Assert.IsAssignableFrom<DispatchingBuilder>(result);
        }

        //AddDispatchimg throws ArgumentNullException when scope is null
        [Fact]
        public void AddDispatching_Throw_ArgumentNullException_When_Scope_Is_Null()
        {
            //Arrange
            IInjectionScope scope = null;

            //Act
            // ReSharper disable once AssignNullToNotNullAttribute
            var ex = Assert.Throws<ArgumentNullException>(() => scope.AddDispatching(typeof(AwesomeRequest).Assembly));

            //Assert
            Assert.True(ex.Message is "Value cannot be null. (Parameter 'scope')");
        }

        //AddDispatching throws ArgumentNullException when assemblies is null
        [Fact]
        public void AddDispatching_Throw_ArgumentNullException_When_Assemblies_Is_Null()
        {
            //Arrange
            var container = CreateContainer();

            //Act
            // ReSharper disable once AssignNullToNotNullAttribute
            var ex = Assert.Throws<ArgumentNullException>(() => container.AddDispatching(null));

            //Assert
            Assert.True(ex.Message is "Value cannot be null. (Parameter 'assemblies')");
        }


    }
}