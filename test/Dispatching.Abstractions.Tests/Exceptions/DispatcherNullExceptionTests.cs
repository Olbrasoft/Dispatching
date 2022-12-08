namespace Olbrasoft.Dispatching.Abstractions.Exceptions;
public class DispatcherNullExceptionTests
{
    [Fact]
    public void TypeOf_DispatcherNullException_IsPublicShouldBeTrue()
    {
        // Arrange
        var type = typeof(DispatcherNullException);

        // Act
        var isPublic = type.IsPublic;

        // Assert
        isPublic.Should().BeTrue();

    }

    [Fact]
    public void TypeOf_DispatcherNullException_ShouldBeAssingableToExpected()
    {
        // Arrange
        var expected = typeof(ArgumentNullException);
        // Act
        var type = typeof(DispatcherNullException);


        // Assert
        type.Should().BeAssignableTo(expected);
    }

    [Fact]
    public void DispatcherNullException_ParamName_ShouldBeSameAsDispatcher()
    {
        // Arrange
        var actual = new DispatcherNullException();

        // Act
        var sut = actual.ParamName;

        // Assert
        sut.Should().BeSameAs("dispatcher");

    }

    [Fact]
    public void TypeOf_DispatcherNullException_AssemblyShouldBeSameAsExpected()
    {
        // Arrange
        var type = typeof(DispatcherNullException);
        var expected = typeof(BaseRequest<>).Assembly;

        // Act
        var assembly = type.Assembly;

        // Assert
        assembly.Should().BeSameAs(expected);

    }


}
