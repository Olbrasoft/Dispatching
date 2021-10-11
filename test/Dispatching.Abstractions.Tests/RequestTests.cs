using Moq;
using System;
using System.Diagnostics.CodeAnalysis;
using System.Threading;
using System.Threading.Tasks;
using Xunit;

namespace Olbrasoft.Dispatching.Abstractions
{
    [SuppressMessage("ReSharper", "AssignNullToNotNullAttribute")]
    public class RequestTests
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

        /// <summary>
        /// Constructor of class Request with mandatory dispatcher parameter, throw an argument exception when the dispatcher is null
        /// </summary>
        [Fact]
        public void AwesomeRequest_Throw_ArgumentException_When_Dispatcher_Is_Null()
        {
            //Arrange
            IDispatcher dispatcher = null;

            //Assert
            var ex = Assert.Throws<ArgumentNullException>(() => new Request<object>(dispatcher));
        }

        /// <summary>
        /// Constructor of class Request with mandatory handler parameter, throw an argument exception when the handler is null.;
        /// </summary>
        [Fact]
        public void AwesomeRequest_Throw_ArgumentException_When_handler_Is_Null()
        {
            //Arrange
            IRequestHandler<Request<object>, object> handler = null;

            //Assert
            Assert.Throws<ArgumentNullException>(() => new Request<object>(handler));
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
        public async Task AwesomeRequest_ExecuteAsync_Called_Dispatcher_DispatchAsync_When_Dispatcher_Is_Set_Null()
        {
            //Arrange
            var mockDispatcher = new Mock<IDispatcher>();
            var dispatcher = mockDispatcher.Object;

            var request = new Request<object>(dispatcher);
            dispatcher = null;

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

            //Actls
            await request.ExecuteAsync();

            //Assert
            mockHandler.Verify(prop => prop.HandleAsync(It.IsAny<IRequest<object>>(), It.IsAny<CancellationToken>()), Times.Once);
        }
    }
}