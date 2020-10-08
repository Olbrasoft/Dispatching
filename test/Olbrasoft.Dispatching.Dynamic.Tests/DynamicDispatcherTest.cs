using Microsoft.Extensions.DependencyInjection;
using Moq;
using Olbrasoft.Dispatching.Common;
using System.Linq;
using Xunit;

namespace Olbrasoft.Dispatching.Dynamic.Tests
{
    public class DynamicDispatcherTest
    {
        [Fact]
        public void Instance_Implement_Interface_IDispatcher()
        {
            //Arrange
            var type = typeof(IDispatcher);
            var factoryMock = new Mock<Factory>();

            //Act
            var dispatcher = new DynamicDispatcher(factoryMock.Object);

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

            var response = new AwesomeRequest(dispatcher);

            //Act
            var result = await dispatcher.DispatchAsync(response, default);

            //Assert
            Assert.IsAssignableFrom<AwesomeResponse>(result);
        }
    }
}