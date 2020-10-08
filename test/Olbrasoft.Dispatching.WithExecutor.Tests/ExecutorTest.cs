using Moq;
using Olbrasoft.Dispatching.Common;
using System.Threading;
using Xunit;

namespace Olbrasoft.Dispatching.WithExecutor.Tests
{
    public class ExecutorTest
    {
        [Fact]
        public void Instance_Implement_Interface_IExecutor_Of_Object()
        {
            //Arrange
            var type = typeof(IExecutor<object>);
            var mockHandler = HadlerMock();

            //Act
            var executor = new Executor<IRequest<object>, object>(mockHandler.Object);

            //Assert
            Assert.IsAssignableFrom(type, executor);
        }

        private static Mock<IRequestHandler<IRequest<object>, object>> HadlerMock()
        {
            return new Mock<IRequestHandler<IRequest<object>, object>>();
        }

        [Fact]
        public async System.Threading.Tasks.Task ExecuteAsync_Called_Handler_HandleAsync()
        {
            //Arrange
            var mockHandler = HadlerMock();
            var executor = new Executor<IRequest<object>, object>(mockHandler.Object);
            var mockRequest = new Mock<IRequest<object>>();

            //Act
            await executor.ExecuteAsync(mockRequest.Object);

            //Assert
            mockHandler.Verify(p => p.HandleAsync(It.IsAny<IRequest<object>>(), It.IsAny<CancellationToken>()), Times.Once);
        }
    }
}