using FluentAssertions;
using Moq;
using System;
using Xunit;

namespace Olbrasoft.Dispatching.Abstractions
{
    public class DispatcherBaseTests
    {
        [Fact]
        public void Dispatcher_Is_Abstract()
        {
            //Arrange
            var type = typeof(DispatcherBase);

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
            var mokDispatcher = new Mock<DispatcherBase>(factory);

            //Act
            var dispatcher = mokDispatcher.Object;

            //Assert
            Assert.IsAssignableFrom<IDispatcher>(dispatcher);
        }

        public Factory CreateFactory()
        {
            Factory factory = CreateHandler<IHandler>;

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
            Assert.IsAssignableFrom<DispatcherBase>(dispatcher);
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
            Factory factory = null;
#pragma warning restore 8600

            //Assert
#pragma warning disable 8604
            Assert.Throws<ArgumentNullException>(() => new AwesomeDispatcher(factory));
#pragma warning restore 8604
        }

        [Fact]
        public void GetHandler_Adds_Handler_To_Dictionary()
        {
            //Arrange
            var factoryMock = new Mock<Factory>();
            factoryMock.Setup(p => p(It.IsAny<Type>())).Returns(new AwesomeHandler());
            var dispatcher = new AwesomeDispatcher(factoryMock.Object);

            //Act
            dispatcher.CallProtectedFunctionGetHandler();
            dispatcher.CallProtectedFunctionGetHandler();

            //Assert
            factoryMock.Verify(p => p(It.IsAny<Type>()), Times.AtMostOnce);
        }

        [Fact]
        public void GetHandler_Throw_Invalid_Operation_Factory_Not_Fount_ExactHandlerType()
        {
            //Arrange
            var factoryMock = new Mock<Factory>();
            factoryMock.Setup(p => p(It.IsAny<Type>())).Returns(null);
            var dispatcher = new AwesomeDispatcher(factoryMock.Object);

            //Act
            var act = () => dispatcher.CallProtectedFunctionGetHandler();

            //Assert
            act.Should().Throw<InvalidOperationException>();
        }
    }
}