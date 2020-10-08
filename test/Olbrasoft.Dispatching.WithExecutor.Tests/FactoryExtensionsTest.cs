﻿using Moq;
using Olbrasoft.Dispatching.Common;
using System;
using Xunit;

namespace Olbrasoft.Dispatching.WithExecutor.Tests
{
    public class FactoryExtensionsTest
    {
        public static object Factory(Type type)
        {
            return new Mock<IExecutor<object>>().Object;
        }

        [Fact]
        public void CreateExecutor_Return_IExecutor_Of_Object()
        {
            //Arrange
            Factory factory = Factory;

            //Act
            var executor = factory.CreateExecutor<object>(typeof(IRequestHandler<IRequest<object>, object>));

            //Assert
            Assert.IsAssignableFrom<IExecutor<object>>(executor);
        }
    }
}