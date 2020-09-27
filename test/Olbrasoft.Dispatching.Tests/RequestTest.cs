using Moq;
using System.Threading;
using System.Threading.Tasks;
using Xunit;

namespace Olbrasoft.Dispatching.Tests
{
    public class RequestTest
    {
        [Fact]
        public void Request_Implement_Interface_IRequest()
        {
            //Arrange
            var type = typeof(IRequest<object>);

            //Act
            var result = type.IsAssignableFrom(typeof(Request<object>));

            //Assert
            Assert.True(result);
        }

        [Fact]
        public async Task AwesomeRequest_ExecuteAsync_Called_Dispatcher_DispatchAsync()
        {
            //Arrange
            var mockDispatcher = new Mock<IDispatcher>();
            var request = new Request<object>(mockDispatcher.Object);

            //Act
            await request.ExecuteAsync();

            //Assert
            mockDispatcher.Verify(p => p.DispatchAsync(It.IsAny<IRequest<object>>(), It.IsAny<CancellationToken>()), Times.Once);
        }

        [Fact]
        public async Task AwesomeRequest_ExecuteAsync_Called_Handler_HandleAsync()
        {
            //Arrange
            var mockHandler = new Mock<IRequestHandler<IRequest<object>, object>>();
            var request = new Request<object>(mockHandler.Object);

            //Act
            await request.ExecuteAsync();

            //Assert
            mockHandler.Verify(prop => prop.HandleAsync(It.IsAny<IRequest<object>>(), It.IsAny<CancellationToken>()), Times.Once);
        }
    }
}