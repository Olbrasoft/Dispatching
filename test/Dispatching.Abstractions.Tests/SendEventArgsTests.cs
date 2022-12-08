using Shouldly;

namespace Olbrasoft.Dispatching.Abstractions;
public class SendEventArgsTests
{
    [Fact]
    public void SendchEventArgs_ObjectAndExpectedResponse_ResponseShouldBeSameAsExpected()
    {
        // Arrange

        var expected = "expected response";

        // Act
        var uow = new SendEventArgs(new object(), expected);

        // Assert
        uow.Response.ShouldBeSameAs(expected);

    }

    [Fact]
    public void SendchEventArgs_NullRequest_ShouldThrowRequestNullException()
    {
        // Arrange
        IRequest<object> request = null;

        // Act
        var act = () => new SendEventArgs(request);

        // Assert
        act.ShouldThrow<RequestNullException>();

    }


    [Fact]
    public void SendchEventArgs_MockRequest_ShouldBeAssingableToEventArgs()
    {
        // Arrange
        var sut = new Mock<IRequest<object>>();

        // Act
        var uow = new SendEventArgs(sut);

        // Assert
        uow.ShouldBeAssignableTo<EventArgs>();
    }
}
