using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Olbrasoft.Dispatching.Abstractions.Exceptions;
public class RequestHandlerNullExceptionTests
{
    //RequestHandlerNullException is Public
    [Fact]
    public void RequestHandlerNullException_ShouldBePublic()
    {
        //Arrange
        var type = typeof(RequestHandlerNullException);
        //Act
        var isPublic = type.IsPublic;
        //Assert
        Assert.True(isPublic);
    }

    //RequestHandlerNullException Assembly is Olbrasoft.Dispatching.Abstractions
    [Fact]
    public void RequestHandlerNullException_ShouldBeInOlbrasoft_Dispatching_Abstractions()
    {
        //Arrange
        var type = typeof(RequestHandlerNullException);
        //Act
        var assemblyName = type.Assembly.GetName().Name;
        //Assert
        Assert.Equal("Olbrasoft.Dispatching.Abstractions", assemblyName);
    }

    //RequestHandlerNullException inherith from ArgumentNullException
    [Fact]
    public void RequestHandlerNullException_ShouldInheritFromArgumentNullException()
    {
        //Arrange
        var type = typeof(RequestHandlerNullException);
        //Act
        var baseType = type.BaseType;
        //Assert
        Assert.Equal(typeof(ArgumentNullException), baseType);
    }

    //RequestHandlerNullException constructor with out parameter set paramName "requestHandler"
    [Fact]
    public void Constructor_ShouldSetParamNameRequestHandler()
    {
        //Arrange
        var exception = new RequestHandlerNullException();
        //Act
        var paramName = exception.ParamName;
        //Assert
        Assert.Equal("requestHandler", paramName);
    }
    
    //RequestHandlerNullException constructor with parameter set paramName
    [Fact]
    public void Constructor_ShouldSetParamName()
    {
        //Arrange
        var paramName = "paramName";
        var exception = new RequestHandlerNullException(paramName);
        //Act
        var result = exception.ParamName;
        //Assert
        Assert.Equal(paramName, result);
    }

}
