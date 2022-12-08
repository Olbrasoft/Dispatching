using System.Diagnostics.CodeAnalysis;
using Xunit;

namespace Olbrasoft.Dispatching.Abstractions
{
    [SuppressMessage("ReSharper", "AssignNullToNotNullAttribute")]
    public class BaseRequestTests
    {
        [Fact]
        public void Request_Implement_Interface_IRequest()
        {
            //Arrange
            var type = typeof(IRequest<object>);

            //Act
            var result = type.IsAssignableFrom(typeof(BaseRequest<object>));

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
            var ex = Assert.Throws<DispatcherNullException>(() => new BaseRequest<object>(dispatcher));
        }

   

        [Fact]
        public void BaseRequest_MockDispatcher_DispatcherShouldBeSameAsMockDispatcher()
        {
            // Arrange
            var sut = new Mock<IDispatcher>().Object;
            // Act
            var req = new BaseRequest<object>(sut);

            // Assert
            req.Dispatcher.Should().BeSameAs(sut);
        }

      


    }
}