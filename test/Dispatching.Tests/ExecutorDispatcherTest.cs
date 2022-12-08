using Moq;
using System;
using System.Threading;
using System.Threading.Tasks;
using Xunit;

namespace Olbrasoft.Dispatching
{
    public class ExecutorDispatcherTest
    {
        [Fact]
        public void Dispatcher_Implement_Interface_IDispatcher()
        {
            //Arrange
            var type = typeof(IDispatcher);
            var mockFactory = new Mock<CreateHandler>();

            //Act
            var dispatcher = new ExcutorDispatcher(mockFactory.Object);

            //Assert
            Assert.IsAssignableFrom(type, dispatcher);
        }

        [Fact]
        public void Dispatcher_Inherit_From_DispatcherBase()
        {
            //Arrange
            var type = typeof(BaseDispatcher);
            var mockFactory = new Mock<CreateHandler>();

            //Act
            var dispatcher = new ExcutorDispatcher(mockFactory.Object);

            //Assert
            Assert.IsAssignableFrom(type, dispatcher);
        }

        [Fact]
        public async void DispatchAsync()
        {
            //Arrange
            CreateHandler mockFactory = Factory;

            var dispatcher = new ExcutorDispatcher(mockFactory);
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