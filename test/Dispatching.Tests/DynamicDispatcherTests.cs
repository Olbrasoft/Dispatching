using Moq;
using Olbrasoft.Dispatching;
using Olbrasoft.Dispatching.Abstractions.Exceptions;
using Shouldly;
using System;
using System.Linq;
using System.Threading.Tasks;
using Xunit;

namespace Dispatching.Dynamic.Tests
{
    public class DynamicDispatcherTests
    {
        [Fact]
        public void Instance_Implement_Interface_IDispatcher()
        {
            //Arrange
            var type = typeof(IDispatcher);

            //Act
            var dispatcher = new DynamicDispatcher(CreateFactory());

            //Assert
            Assert.IsAssignableFrom(type, dispatcher);
        }

        [Fact]
        public async Task When_Request_Is_Null_DispatchAsync_Throws_Null_Exception()
        {
            //Arrange
            var dispatcher = new DynamicDispatcher(CreateFactory());
            BaseRequest<object> request = null;

            //Assert
            await Assert.ThrowsAsync<RequestNullException>(() => dispatcher.DispatchAsync(request));
        }

        [Fact]
        public void DinamicDispatcher_NullCreateHandler_ShouldThrowCreateHandlerNullException  ()
        {
            //Arrange
            CreateHandler creteHandler = null;

            //Act
            var act = () => new DynamicDispatcher(creteHandler);

            //Assert
            act.ShouldThrow<CreateHandlerNullException>();
        }

        [Fact]
        public void DynamicDispatcher_Inherit_From_DispatcherBase()
        {
            //Arrange
            var factory = CreateFactory();

            //Act
            var dispatcher = new DynamicDispatcher(factory);

            //Assert
            Assert.IsAssignableFrom<BaseDispatcher>(dispatcher);
        }

        private static CreateHandler CreateFactory()
        {
            return new Mock<CreateHandler>().Object;
        }
    }
}