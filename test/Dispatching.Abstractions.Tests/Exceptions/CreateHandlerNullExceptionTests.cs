using Shouldly;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Olbrasoft.Dispatching.Abstractions.Exceptions;
public class CreateHandlerNullExceptionTests
{
    [Fact]
    public void TypeOf_CreateHandlerNullException_IsPublicShouldBeTrue()
    {
        // Arrange
        var type = typeof(CreateHandlerNullException);
        // Act
        var isPublic = type.IsPublic;

        // Assert
        isPublic.Should().BeTrue();
    }

    [Fact]
    public void TypeOf_CreateHandlerNullException_AsseblyShouldBySameAsExpected()
    {
        // Arrange
        var expected = typeof(CreateHandler).Assembly;    

        // Act
        var type = typeof(CreateHandlerNullException);

        // Assert
        type.Assembly.ShouldBeSameAs(expected);
    }

    [Fact]
    public void CreateHandlerNullException_WithOutParmather_ShouldBeAssingableToExpected()
    {
        // Arrange
        var expected = typeof(ArgumentNullException);

        // Act
        var sut = new CreateHandlerNullException();

        // Assert
        sut.ShouldBeAssignableTo(expected);

    }

    [Fact]
    public void CreateHandlerNullException_WithOutParams_ParamNameSholdBeCreateHandler()
    {
        // Arrange
        var sut=new CreateHandlerNullException();

        // Act
        var paramName = sut.ParamName;

        // Assert
        paramName.ShouldBe("createHandler");

    }



}
