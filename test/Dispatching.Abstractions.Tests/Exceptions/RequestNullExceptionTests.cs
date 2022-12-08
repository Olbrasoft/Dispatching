namespace Olbrasoft.Dispatching.Abstractions.Exceptions;
public class RequestNullExceptionTests
{
    [Fact]
    public void Typeof_RequestNullException_IsPublicSchouldBeTrue()
    {
        // Arrange
        var sut = typeof(RequestNullException);

        // Act
        var isPublic = sut.IsPublic;

        // Assert
        isPublic.Should().BeTrue();

    }


    [Fact]
    public void RequestNullException_GetType_ShouldBeAssingableExpected()
    {
        // Arrange
        var expected = typeof(ArgumentException);
        var exception = new RequestNullException();

        // Act
        var sut = exception.GetType();

        // Assert
        sut.Should().BeAssignableTo(expected);

    }


    [Fact]
    public void RequestNullException_GetType_AssemblyShouldBeSameAsExpected()
    {
        // Arrange
        var ex = new RequestNullException();

        // Act
        var sut = ex.GetType();

        // Assert
        sut.Assembly.Should().BeSameAs(typeof(BaseRequest<>).Assembly);
    }

}
