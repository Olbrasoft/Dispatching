using Shouldly;
using Xunit;

namespace Olbrasoft.Dispatching.Abstractions.Exceptions;
public class CreateHandlerExceptionTests
{
    [Fact]
    public void Typeof_CreateHandlerException_IsPublicShouldBeTrue()
    {
        // Arrange
        var type = typeof(CreateHandlerException);
        // Act
        var isPublic = type.IsPublic;
        // Assert
        isPublic.ShouldBeTrue();
    }

    [Fact]
    public void TypeOf_CreateHandlerException_AssemblyShouldBeSameAsExpected()
    {
        // Arrange
        var expected = typeof(CreateHandler).Assembly;
        // Act
        var assembly = typeof(CreateHandlerException).Assembly;

        // Assert
        assembly.ShouldBeSameAs(expected);
    }

    [Fact]
    public void CreateHandlerException_WithMockObject_ShouldBeAssingableToExpected()
    {
        // Arrange
        var expected = typeof(InvalidOperationException);
        // Act
        var sut = new CreateHandlerException(typeof(object));

        // Assert
        sut.ShouldBeAssignableTo(expected);
        
    }

    [Fact]
    public void CreateHandlerException_TypeOfAwesomeHandler_MessageContainsAwesomeHandlerShouldBeTrue()
    {
        // Arrange
        var type = typeof(AwesomeHandler);
       

        // Act
        var sut = new CreateHandlerException(type);

        // Assert
        sut.Message.Contains("AwesomeHandler").ShouldBeTrue();
    }

}
