using Grace.DependencyInjection;
using Olbrasoft.Dispatching.DI.Grace.Common;
using System;
using System.Reflection;
using Xunit;

namespace Olbrasoft.Dispatching.Dynamic.DI.Grace
{
    public class DispatchingBuilderExtensionsTests
    {
        //DispatchingBuilderExtensions is public class
        [Fact]
        public void Is_public_class()
        {
            //Arrange
            var type = typeof(DispatchingBuilderExtensions);
            
            //Act
            //Assert
            Assert.True(type.IsPublic);
        }

        //assembly Dispatching.Dynamic.DI.Grace
        [Fact]
        public void Is_in_assembly_Dispatching_Dynamic_DI_Grace()
        {
            //Arrange
            var type = typeof(DispatchingBuilderExtensions);

            //Act
            //Assert
            Assert.Equal("Olbrasoft.Dispatching.Dynamic.DI.Grace", type.Namespace);
        
        }

        //DispatchingBuilderExtensions is static class
        [Fact]
        public void Is_static_class()
        {
            //Arrange
            var type = typeof(DispatchingBuilderExtensions);

            //Act
            //Assert
            Assert.True(type.IsAbstract && type.IsSealed);
        }
        
        //DispatchingBuilderExtensions has method UseDynamicDispatcher
        [Fact]
        public void Has_method_UseDynamicDispatcher()
        {
            //Arrange
            var type = typeof(DispatchingBuilderExtensions);

            //Act
            var method = type.GetMethod("UseDynamicDispatcher");

            //Assert
            Assert.NotNull(method);
        }


        //UseDynamicDispatcher has one parameter builder type DispatchingBuilder
        [Fact]
        public void UseDynamicDispatcher_has_one_parameter_builder_type_DispatchingBuilder()
        {
            //Arrange
            var type = typeof(DispatchingBuilderExtensions);
            var method = type.GetMethod("UseDynamicDispatcher");

            //Act
            var parameters = method.GetParameters();

            //Assert
            Assert.Single(parameters);
            Assert.Equal(typeof(DispatchingBuilder), parameters[0].ParameterType);
        }

        //UseDynamicDispatcher (this DispatchingBuilder builder)
        [Fact]
        public void UseDynamicDispatcher_this_DispatchingBuilder_builder()
        {
            //Arrange
            var type = typeof(DispatchingBuilderExtensions);

            //Act
            var method = type.GetMethod("UseDynamicDispatcher");
          

            //Assert
            Assert.True(method.IsDefined(typeof(System.Runtime.CompilerServices.ExtensionAttribute), false));
        }

        //UseDynamicDispatcher throw ArgumentNullException when builder is null
        [Fact]
        public void UseDynamicDispatcher_throw_ArgumentNullException_when_builder_is_null()
        {
            // Arrange
            DispatchingBuilder builder = null;

            // Act
#pragma warning disable IDE0039 // Use local function
            Action act = () => builder.UseDynamicDispatcher();
#pragma warning restore IDE0039 // Use local function

            // Assert
            Assert.Throws<ArgumentNullException>(act);
        }

        //UseDynamicDispatcher return DispatchingBuilder
        [Fact]
        public void UseDynamicDispatcher_return_DispatchingBuilder()
        {
            // Arrange
            var type = typeof(DispatchingBuilderExtensions);
            var method = type.GetMethod("UseDynamicDispatcher");

            // Act
            var result = method.ReturnType;

            // Assert
            Assert.Equal(typeof(DispatchingBuilder), result);

        }


        //UseDynamicDispatcher register DynamicDispatcher as IDispatcher
        [Fact]
        public void UseDynamicDispatcher_register_DynamicDispatcher_as_IDispatcher()
        {
            // Arrange
            var container = new DependencyInjectionContainer();
            var builder = new DispatchingBuilder(container);
           
            // Act
            builder.UseDynamicDispatcher();
            var result = builder.Scope.Locate<IDispatcher>();
           
            // Assert
            Assert.IsType<DynamicDispatcher>(result);
        }
    }
}
