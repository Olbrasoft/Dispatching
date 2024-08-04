using Microsoft.Extensions.DependencyInjection;
using Moq;
using Olbrasoft.Dispatching;
using System;
using System.Linq;
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
        public async System.Threading.Tasks.Task DispatchAsync_Return_AwesomeResult()
        {
            //Arrange
            IServiceCollection services = new ServiceCollection();
            services.AddTransient<Factory>(p => p.GetService);
            services.AddTransient<IDispatcher, DynamicDispatcher>();
            services.AddTransient(typeof(AwesomeRequestHandler).GetInterfaces().First(), typeof(AwesomeRequestHandler));
            var provider = services.BuildServiceProvider();

            var dispatcher = provider.GetService<IDispatcher>();

            var request = new AwesomeRequest();

            //Act
            var result = await dispatcher.DispatchAsync(request, default);

            //Assert
            Assert.IsAssignableFrom<AwesomeResponse>(result);
        }

        [Fact]
        public async System.Threading.Tasks.Task When_Request_Is_Null_DispatchAsync_Throws_Null_Exception()
        {
            //Arrange
            var dispatcher = new DynamicDispatcher(CreateFactory());
            IRequest<object> request = null;

            //Assert
            await Assert.ThrowsAsync<ArgumentNullException>(() => dispatcher.DispatchAsync(request));
        }

        [Fact]
        public void When_Factory_Is_Null_Constructor_Throw_Null_Exception()
        {
            //Arrange
            Factory factory = null;

            //Assert
            Assert.Throws<ArgumentNullException>(() => new DynamicDispatcher(factory));
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

        private static Factory CreateFactory()
        {
            return new Mock<Factory>().Object;
        }
    }
}