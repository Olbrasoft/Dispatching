using Moq;
using System;
using System.Threading;
using System.Threading.Tasks;
using Xunit;

namespace Olbrasoft.Dispatching
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
        public void Dispatcher_Inherit_From_DispatcherBase()
        {
            //Arrange
            var type = typeof(DispatcherBase);
            var mockFactory = new Mock<Factory>();

            //Act
            var dispatcher = new Dispatcher(mockFactory.Object);

            //Assert
            Assert.IsAssignableFrom(type, dispatcher);
        }

        [Fact]
        public async void DispatchAsync()
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

        public static IHandler Factory(Type type) 
        {
            var mockExecutor = new Mock<IExecutor<object>>();

            mockExecutor.Setup(p => p.ExecuteAsync(It.IsAny<IRequest<object>>(), It.IsAny<CancellationToken>()))
                .Returns(Task.FromResult(new object()));

            return mockExecutor.Object;
        }
    }
}