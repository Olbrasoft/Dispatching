using Shouldly;

namespace Olbrasoft.Dispatching.Abstractions
{
    public class BaseDispatcherTests
    {
        [Fact]
        public void Dispatcher_Is_Abstract()
        {
            //Arrange
            var type = typeof(BaseDispatcher);

            //Act
            var isAbstract = type.IsAbstract;

            //Assert
            Assert.True(isAbstract);
        }

        [Fact]
        public void Dispatcher_Implement_Interface_IDispatcher()
        {
            //Arrange
            var factory = CreateFactory();
            var mokDispatcher = new Mock<BaseDispatcher>(factory);

            //Act
            var dispatcher = mokDispatcher.Object;

            //Assert
            Assert.IsAssignableFrom<IDispatcher>(dispatcher);
        }

        public CreateHandler CreateFactory()
        {
            CreateHandler factory = CreateHandler<IHandler>;

            return factory;
        }

        [Fact]
        public void AwesomeDispatcher_Inherit_From_Dispatcher()
        {
            //Arrange
            var factory = CreateFactory();

            //Act
            var dispatcher = new AwesomeDispatcher(factory);
         
            //Assert
            Assert.IsAssignableFrom<BaseDispatcher>(dispatcher);
        }

        [Fact]
        public void GetHandler_Return_Call_Factory()
        {
            //Arrange
            var factory = CreateFactory();

            //Act
            var dispatcher = new AwesomeDispatcher(factory);

            //Act
            var handler = dispatcher.CallProtectedFunctionGetHandler();

            //Assert
            handler.Should().BeSameAs(Handler);
        }


        private IHandler _handler;

        private IHandler Handler => _handler ??= new AwesomeHandler();

        private IHandler CreateHandler<THandler>(Type type) where THandler : IHandler
        {
            return Handler;
        }

        [Fact]
        public void Throw_Exception_When_Argument_Factory_Is_Null()
        {
            //Arrange
#pragma warning disable 8600
           CreateHandler createHandler = null;
#pragma warning restore 8600

            //act 
            var act = () => new AwesomeDispatcher(createHandler);

            //Assert

            act.ShouldThrow<CreateHandlerNullException>();

        }

        [Fact]
        public void GetHandler_Adds_Handler_To_Dictionary()
        {
            //Arrange
            var factoryMock = new Mock<CreateHandler>();
            factoryMock.Setup(p => p(It.IsAny<Type>())).Returns(new AwesomeHandler());
            var dispatcher = new AwesomeDispatcher(factoryMock.Object);

            //Act
            dispatcher.CallProtectedFunctionGetHandler();
            dispatcher.CallProtectedFunctionGetHandler();

            //Assert
            factoryMock.Verify(p => p(It.IsAny<Type>()), Times.AtMostOnce);
        }



        [Fact]
        public void GetHandler_NullHandler_ShouldThrowCreateHandlerException()
        {
            //Arrange
            var factoryMock = new Mock<CreateHandler>();
           
            IHandler nullHandler = null;

            factoryMock.Setup(p => p(It.IsAny<Type>())).Returns(nullHandler);
            var dispatcher = new AwesomeDispatcher(factoryMock.Object);

            //Act
            var act = () => dispatcher.CallProtectedFunctionGetHandler();

            //Assert
            act.ShouldThrow<CreateHandlerException>();
        }


        [Fact]
        public async void DispatchAsync_WhenEventSubscriber_EvenArgsRequestShouldBeSameAsRequest()
        {
            // Arrange
            var factoryMock = new Mock<CreateHandler>();
            var dispatcher = new PingDispatcher(factoryMock.Object);
            object who = null;
            object requestAdept =null;

            dispatcher.Sended += (sender, e) => { who = sender; requestAdept = e.Request;  };

            var r = new BaseRequest<object>(dispatcher);
            // Act
            await dispatcher.DispatchAsync(r);

            // Assert
            who.GetType().Should().BeSameAs(typeof(PingDispatcher));
            requestAdept.Should().BeSameAs(r);
        }
    }
}