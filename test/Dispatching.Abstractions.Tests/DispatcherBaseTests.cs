﻿namespace Olbrasoft.Dispatching.Abstractions
{
    public class DispatcherBaseTests
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

        public Factory CreateFactory()
        {
            Factory factory = CreateHandler;

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
            var dispatcher = new AwesomeDispatcher(factory);

            //Act
            var handler = dispatcher.CallProtectedFunctionGetHandler();

            //Assert
            Assert.Same(Handler, handler);
        }

        //add test argument null exception type input in GetHandler
        [Fact]
        public void GetHandler_Throw_ArgumentNullException_Type()
        {
            //Arrange
            var factory = CreateFactory();
            var dispatcher = new AwesomeDispatcher(factory);

            //Assert
            Assert.Throws<ArgumentNullException>(() => dispatcher.CallProtectedFunctionGetHandlerWithNUll());
        }


        [Fact]
        public void MyTestMethod()
        {
            //Arrange
            Factory factory = NullHandler;

            //Act
            var dispatcher = new AwesomeDispatcher(factory);

            //Assert
            Assert.Throws<InvalidOperationException>(() => dispatcher.CallProtectedFunctionGetHandler());
        }

        private object NullHandler(Type type)
        {
            return null;
        }

        private IHandler _handler;

        private IHandler Handler => _handler ??= new AwesomeHandler();

        private object CreateHandler(Type type)
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
    }
}