using FluentAssertions.ArgumentMatchers.Moq;
using Olbrasoft.Extensions;
using Shouldly;
using System.Threading;
using System.Threading.Tasks;
using Xunit;

namespace Olbrasoft.Dispatching.Abstractions;
public class BaseRequestExtesionsTests
{
    [Fact]
    public void TypeOf_BaseRequestExtensions_IsPublicShouldBeTrue()
    {
        // Arrange
        var type = typeof(BaseRequestExtesions);
        // Act
        var isPublic = type.IsPublic;

        // Assert
        isPublic.Should().BeTrue();
    }

    [Fact]
    public void TypeOf_BaseRequestExtensions_IsStaticShouldBeTrue()
    {
        // Arrange
        var type = typeof(BaseRequestExtesions);
        // Act
        var isStatic = type.IsStatic();
        // Assert
        isStatic.Should().BeTrue();
    }

    [Fact]
    public void TypeOf_BaseRequestExtensions_AssemblyShouldBeSameAsBaseRequestAssembly()
    {
        // Arrange
        var type = typeof(BaseRequestExtesions);
        var expected = typeof(BaseRequest<>).Assembly;

        // Act
        var assembly = type.Assembly;

        // Assert
        assembly.Should().BeSameAs(expected);

    }

    [Fact]
    public void ToResponseAsync_BaseRequestAndCancelationTokenWhenTokenCanceled_ThenShouldBeThrowExactlyOperationCanceledException()
    {
        // Arrange
        var request = new BaseRequest<object>(new Mock<IDispatcher>().Object);

        var cts = new CancellationTokenSource();
        cts.Cancel();

        // Act
        Func<Task<object>> act = () => BaseRequestExtesions.ToResponseAsync(request: request, token: cts.Token);

        // Assert
        act.Should().ThrowExactlyAsync<OperationCanceledException>();
    }

    [Fact]
    public async void ToResponseAsync_NullRequest_ShouldBeThrowExactlyRequestNullException()
    {
        // Arrange
        BaseRequest<object> sut = null;

        // Act
        var act = () => BaseRequestExtesions.ToResponseAsync(sut);

        // Assert
        await act.Should().ThrowExactlyAsync<RequestNullException>();
    }


    [Fact]
    public async void ToResponseAsync_BaseRequestWithMockDispatcher_VerifyDispatchAsyncMethodOnMockDispatcherShouldBeCallledOnce()
    {
        // Arrange
        var mockDispatcher = new Mock<IDispatcher>();
        var sut = new BaseRequest<object>(mockDispatcher.Object);

        // Act
        await BaseRequestExtesions.ToResponseAsync(sut);

        // Assert
        mockDispatcher.Verify(m => m.DispatchAsync(Its.EquivalentTo(sut), It.IsAny<CancellationToken>()), Times.Once);

    }

    [Fact]
    public async void ToResponseAsync_WhenDispatcherIsNull_ShouldThrowExactlyDispatcherNullException()
    {
        // Arrange
        var sut = new AwesomeRequest();

        // Act
        var act = () => BaseRequestExtesions.ToResponseAsync(sut);

        // Assert
        await act.ShouldThrowAsync<DispatcherNullException>();

    }
}
