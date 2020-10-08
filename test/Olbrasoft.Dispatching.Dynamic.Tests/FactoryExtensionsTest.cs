using Moq;
using Olbrasoft.Dispatching.Common;
using Olbrasoft.Extensions;
using System;
using Xunit;

namespace Olbrasoft.Dispatching.Dynamic
{
    public class FactoryExtensionsTest
    {
        public static object Factory(Type type)
        {
            return new Mock<IRequestHandler<Request<AwesomeResponse>, AwesomeResponse>>().Object;
        }

        [Fact]
        public void Is_Static()
        {
            //Arrange
            var type = typeof(FactoryExtensions);

            //Act
            var result = type.IsStatic();

            //Assert
            Assert.True(result);
        }

        [Fact]
        public void Create_Return_IRequestHandler_Of_AwesomeRequest_Comma_AwesomeResult()
        {
            //Arrange
            var type = typeof(IRequestHandler<AwesomeRequest, AwesomeResponse>);
            Factory factory = Factory;

            //Act
            var handler = factory.CreateHandler(typeof(IRequestHandler<IRequest<AwesomeResponse>, AwesomeResponse>));

            //Assert
            Assert.IsAssignableFrom(type, handler);
        }
    }
}