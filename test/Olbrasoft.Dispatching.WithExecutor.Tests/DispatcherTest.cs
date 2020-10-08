using Moq;
using Olbrasoft.Dispatching.Common;
using System;
using System.Threading;
using System.Threading.Tasks;
using Xunit;

namespace Olbrasoft.Dispatching.WithExecutor.Tests
{
    public class DispatcherTest
    {
        [Fact]
        public void Dispatcher_Implement_Interface_IDispatcher()
        {
            //Arrange
            var type = typeof(IDispatcher);
            var mockFactory = new Mock<Factory>();

            //Act
            var dispatcher = new Dispatcher(mockFactory.Object);

            //Assert
            Assert.IsAssignableFrom(type, dispatcher);
        }

        [Fact]
        public async void DispatcheAsync()
        {
            //Arrange
            Factory mockFactory = Factory;

            var dispatcher = new Dispatcher(mockFactory);
            var mockRequest = new Mock<IRequest<object>>();

            //Act
            var result = await dispatcher.DispatchAsync(mockRequest.Object);

            //Assert
            Assert.IsAssignableFrom<object>(result);
        }

        public static object Factory(Type type)
        {
            var mockExecutor = new Mock<IExecutor<object>>();

            mockExecutor.Setup(p => p.ExecuteAsync(It.IsAny<IRequest<object>>(), It.IsAny<CancellationToken>()))
                .Returns(Task.FromResult(new object()));

            return mockExecutor.Object;
        }
    }
}