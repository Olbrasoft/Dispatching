using Olbrasoft.Dispatching.Abstractions.Awesomes;
using Olbrasoft.Dispatching.Exceptions;
using System.Linq;
using System.Reflection;

namespace Olbrasoft.Dispatching.Abstractions
{
    public class BaseRequestTests
    {
        //class BaseRequest is public
        [Fact]
        public void BaseRequest_ShouldBePublic()
        {
            //Arrange
            var type = typeof(BaseRequest<>);
            //Act
            var isPublic = type.IsPublic;
            //Assert
            Assert.True(isPublic);
        }

        //BaseRequest Assembly is Olbrasoft.Dispatching.Abstractions
        [Fact]
        public void BaseRequest_ShouldBeInOlbrasoft_Dispatching_Abstractions()
        {
            //Arrange
            var type = typeof(BaseRequest<>);
            //Act
            var assemblyName = type.Assembly.GetName().Name;
            //Assert
            Assert.Equal("Olbrasoft.Dispatching.Abstractions", assemblyName);
        }

       //BaseRequest is abstract class
       [Fact]
       public void BaseRequest_ShouldBeAbstract()
         {
              //Arrange
              var type = typeof(BaseRequest<>);
              //Act
              var isAbstract = type.IsAbstract;
              //Assert
              Assert.True(isAbstract);
         }

        //BaseRequest implement IRequest
        [Fact]
        public void BaseRequest_ShouldImplementIRequest()
        {
            //Arrange
            var type = typeof(BaseRequest<object>);
            //Act
            var implementsIRequest = typeof(IRequest<object>).IsAssignableFrom(type);
            
            //Assert
             Assert.True(implementsIRequest);
        }

        //has proprty Dispatcher
        [Fact]
        public void BaseRequest_ShouldHavePropertyDispatcher()
        {
            //Arrange
            var type = typeof(BaseRequest<object>);
            //Act
            var property = type.GetProperty("Dispatcher");
            //Assert
            Assert.NotNull(property);
        }

        //Dispatcher property is type of IDispatcher
        [Fact]
        public void DispatcherProperty_ShouldBeOfTypeIDispatcher()
        {
            //Arrange
            var property = typeof(BaseRequest<object>).GetProperty("Dispatcher");
            //Act
            var propertyType = property.PropertyType;
            //Assert
            Assert.Equal(typeof(IDispatcher), propertyType);
        }



        //[Fact]
        //public void BaseRequest_Is_Abstract_Class()
        //{
        //    //Arrange
        //    var type = typeof(BaseRequest<string, AwesomeRequestHandler>);
        //    //Act
        //    var isAbstract = type.IsAbstract;
        //    //Assert
        //    Assert.True(isAbstract);
        //}

        ////BaseRequest<,> inherit from BaseRequest<>
        //[Fact]
        //public void BaseRequest_ShouldInheritFromBaseRequest()
        //{
        //    //Arrange
        //    var type = typeof(BaseRequest<string, AwesomeRequestHandler>);
        //    //Act
        //    var baseType = type.BaseType;
        //    //Assert
        //    Assert.Equal(typeof(BaseRequest<string>), baseType);
        //}


        ////BaseRequest<,> has PROPERTY Handler
        //[Fact]
        //public void BaseRequest_ShouldHavePropertyHandler()
        //{
        //    //Arrange
        //    var type = typeof(BaseRequest<string, AwesomeRequestHandler>);
        //    //Act
        //    var property = type.GetProperty("RequestHandler");
        //    //Assert
        //    Assert.NotNull(property);
        //}

        ////RequestHandler property is type of THandler
        //[Fact]
        //public void RequestHandlerProperty_ShouldBeOfTypeTHandler()
        //{
        //    //Arrange
        //    var property = typeof(BaseRequest<string, AwesomeRequestHandler>).GetProperty("RequestHandler");
        //    //Act
        //    var propertyType = property.PropertyType;
        //    //Assert
        //    Assert.Equal(typeof(AwesomeRequestHandler), propertyType);
        //}





    }
}
