using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Olbrasoft.Dispatching.Abstractions.Awesomes;
public class AwesomeRequestHandlerTests
{
    //Implement IRequestHandler
    [Fact]
    public void AwesomeRequestHandler_ShouldImplementIRequestHandler()
    {
        //Arrange
        Type type = typeof(AwesomeRequestHandler);
        //Act
        var implementsIRequestHandler = typeof(IRequestHandler<AwesomeRequest, string>).IsAssignableFrom(type);
        //Assert
        Assert.True(implementsIRequestHandler);
    }

    //HandleAsync return Task<string>
    [Fact]
    public void HandleAsync_ShouldReturnTaskOfString()
    {
        //Arrange
        var handler = new AwesomeRequestHandler();
        //Act
        var method = handler.GetType().GetMethod("HandleAsync");
        var returnType = method.ReturnType;
        //Assert
        Assert.Equal(typeof(Task<string>), returnType);
    }

    //await HandleAsync return "Hello World!"
    [Fact]
    public async Task HandleAsync_ShouldReturnHelloWorld()
    {
        //Arrange
        var handler = new AwesomeRequestHandler();

        var request = new AwesomeRequest();
        //Act
        var result = await handler.HandleAsync(request, CancellationToken.None);
        //Assert
        Assert.Equal("Hello World!", result);
    }


}
