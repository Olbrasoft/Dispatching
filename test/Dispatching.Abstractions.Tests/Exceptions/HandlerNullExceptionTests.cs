namespace Olbrasoft.Dispatching.Abstractions.Exceptions;
public class HandlerNullExceptionTests
{
    [Fact]
    public void TypeOf_HandlerNullException_ShouldBeAssingableOfArgumentNullException()
    {
        // Arrange
        var type = typeof(HandlerNullException);

        // Act


        // Assert
        type.Should().BeAssignableTo<ArgumentNullException>();
    }

    [Fact]
    public void TypeOf_HandlerNullExcaption_IsPublicShouldBeTrue()
    {
        // Arrange
        var type = typeof(HandlerNullException);

        // Act


        // Assert
        type.IsPublic.Should().BeTrue();
    }

    [Fact]
    public void TypeOf_HandlerNullException_AssemblyShouldBeSameAsBaseRequestAssembly()
    {
        // Arrange
        var type = typeof(HandlerNullException);

        // Act

        // Assert
        type.Assembly.Should().BeSameAs(typeof(BaseRequest<>).Assembly);
    }

    [Fact]
    public void HandlerNullException_ParamName_ShouldBeSameAsHandler()
    {
        // Arrange
        var ex = new HandlerNullException();

        // Act
        var sut = ex.ParamName;

        // Assert
        sut.Should().BeSameAs("handler");
    }

}
