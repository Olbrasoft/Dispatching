using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Olbrasoft.Dispatching.Exceptions;

namespace Olbrasoft.Dispatching.Abstractions.Exceptions;
public class DispatcherNullExceptionTests
{
    //DispatcherNullException is public
    [Fact]
    public void DispatcherNullException_ShouldBePublic()
    {
        //Arrange
        var type = typeof(DispatcherNullException);
        //Act
        var isPublic = type.IsPublic;
        //Assert
        Assert.True(isPublic);
    }

    //DispatcherNullException Assembly is Olbrasoft.Dispatching.Abstractions
    [Fact]
    public void DispatcherNullException_ShouldBeInOlbrasoft_Dispatching_Abstractions()
    {
        //Arrange
        var type = typeof(DispatcherNullException);
        //Act
        var assemblyName = type.Assembly.GetName().Name;
        //Assert
        Assert.Equal("Olbrasoft.Dispatching.Abstractions", assemblyName);
    }

    //namespace Olbrasoft.Dispatching.Exceptions
    [Fact]
    public void DispatcherNullException_ShouldBeInOlbrasoft_Dispatching_Exceptions()
    {
        //Arrange
        var type = typeof(DispatcherNullException);
        //Act
        var ns = type.Namespace;
        //Assert
        Assert.Equal("Olbrasoft.Dispatching.Exceptions", ns);
    }

    //Inherits from ArgumentNullException
    [Fact]
    public void DispatcherNullException_ShouldInheritsFromArgumentNullException()
    {
        //Arrange
        var type = typeof(DispatcherNullException);
        //Act
        var baseType = type.BaseType;
        //Assert
        Assert.Equal(typeof(ArgumentNullException), baseType);
    }

    //throw DispatcherNullException by default constructor with no parameters param name is "dispatcher"
    [Fact]
    public void DispatcherNullException_ShouldThrowDispatcherNullExceptionByDefaultConstructorWithNoParametersParamNameIsDispatcher()
    {
        //Arrange
        var exception = new DispatcherNullException();
        //Act
        var paramName = exception.ParamName;
        //Assert
        Assert.Equal("dispatcher", paramName);
    }

    //has constructor with dispatcher param name

    [Fact]
    public void DispatcherNullException_ShouldHaveConstructorWithDispatcherParamName()
    {
        //Arrange
        var type = typeof(DispatcherNullException);
        //Act
        var constructor = type.GetConstructor([typeof(string)]);
        //Assert
        Assert.NotNull(constructor);
    }

    //throw DispatcherNullException by constructor with dispatcherParamName param name is dispatcherParamName
    [Fact]
    public void DispatcherNullException_ShouldThrowDispatcherNullExceptionByConstructorWithDispatcherParamNameParamNameIsDispatcherParamName()
    {
        //Arrange
        var exception = new DispatcherNullException("MyDispatcher");
        //Act
        var paramName = exception.ParamName;
        //Assert
        Assert.Equal("MyDispatcher", paramName);
    }

}
