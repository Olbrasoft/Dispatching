using Moq;
using System;
using System.Threading;
using System.Threading.Tasks;
using Xunit;

namespace Olbrasoft.Dispatching
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


        //add test null exception handler
        [Fact]
        public void Constructor_Throw_ArgumentNullException_Handler()
        {
            //Arrange
            IRequestHandler<IRequest<object>, object> handler = null;

            //Act
            void Act() => new Executor<IRequest<object>, object>(handler);

            //Assert
            Assert.Throws<ArgumentNullException>(Act);
        }


        //test ExecuteAsync thorw argument null exception query
        [Fact]
        public async void ExecuteAsync_Throw_ArgumentNullException_Query()
        {
            //Arrange
            var mockHandler = HadlerMock();
            var executor = new Executor<IRequest<object>, object>(mockHandler.Object);
            IRequest<object> query = null;

            //Act
            async Task Act()
            {
                await executor.ExecuteAsync(query);
            }

            //Assert
            await Assert.ThrowsAsync<ArgumentNullException>(Act);
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