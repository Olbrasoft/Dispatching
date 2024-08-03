using Olbrasoft.Dispatching.Abstractions.Exceptions;
using System.Threading.Tasks;

namespace Olbrasoft.Dispatching.Abstractions.Awesomes;
public class AwesomeRequestTests
{
    //AwesomeRequest inherits from BaseRequest
    [Fact]
    public void AwesomeRequest_ShouldInheritsFromBaseRequest()
    {
        //Arrange
        var type = typeof(AwesomeRequest);
        //Act
        var baseType = type.BaseType;
        //Assert
        Assert.Equal(typeof(BaseRequest<string>), baseType);
    }

    //Constructor throw DispatcherNullException when dispatcher is null
    [Fact]
    public void Constructor_ShouldThrowDispatcherNullException_WhenDispatcherIsNull()
    {
        //Arrange
        IDispatcher dispatcher = null;
        //Act
        Dispatching.Exceptions.DispatcherNullException exception = Assert.Throws<Dispatching.Exceptions.DispatcherNullException>(() => new AwesomeRequest(dispatcher));
        //Assert
        Assert.Equal("dispatcher", exception.ParamName);
    }

    //Constructor set Dispatcher property
    [Fact]
    public void Constructor_ShouldSetDispatcherProperty()
    {
        //Arrange
        var dispatcher = new Mock<IDispatcher>().Object;
        //Act
        var request = new AwesomeRequest(dispatcher);
        //Assert
        Assert.Equal(dispatcher, request.Dispatcher);
    }

    //GetResponse verify call Dispatcher.DispatchAsync
    [Fact]
    public async Task GetResponse_ShouldCallDispatcherDispatchAsync()
    {
        //Arrange
        var dispatcher = new Mock<IDispatcher>();
        var request = new AwesomeRequest(dispatcher.Object);
        //Act
        await request.GetResponseAsync();
        //Assert
        dispatcher.Verify(d => d.DispatchAsync(request,default), Times.Once);
    }

    //GetResponse throw DispatcherNullException when Dispatcher is null
    [Fact]
    public async Task GetResponse_ShouldThrowDispatcherNullException_WhenDispatcherIsNull()
    {
        //Arrange
        var request = new AwesomeRequest();
        //Act
        var exception = await Assert.ThrowsAsync<Dispatching.Exceptions.DispatcherNullException>(() =>  request.GetResponseAsync());
        //Assert
        Assert.Equal("Dispatcher", exception.ParamName);
    }



    //AwesomeRequest<> inherit from BaseRequest<,>  
    [Fact]
    public void AwesomeRequest_ShouldInheritFromBaseRequest()
    {
        //Arrange
        var type = typeof(AwesomeRequestTwo);
        //Act
        var baseType = type.BaseType;
        //Assert
        Assert.Equal(typeof(BaseRequest<string, AwesomeRequestTwo>), baseType);
    }

    //Constructor set RequestHandler property
    [Fact]
    public void Constructor_ShouldSetRequestHandlerProperty()
    {
        //Arrange
        var requestHandler = new Mock<AwesomeRequestHandlerTwo>().Object;
        //Act
        var request = new AwesomeRequestTwo(requestHandler);
        //Assert
        Assert.Equal(requestHandler, request.RequestHandler);
    }

    //Has Constructor with out parameters
    [Fact]
    public void AwesomeRequest_ShouldHaveConstructorWithOutParameters()
    {
        //Arrange
        var type = new AwesomeRequestTwo().GetType();
        //Act
        var constructor = type.GetConstructor(Type.EmptyTypes);
        //Assert
        Assert.NotNull(constructor);
    }

    //Constructor throw RequestHandlerNullException when RequestHandler is null
    [Fact]
    public void Constructor_ShouldThrowRequestHandlerNullException_WhenRequestHandlerIsNull()
    {
        //Arrange
        AwesomeRequestHandlerTwo requestHandler = null;
        //Act
        var exception = Assert.Throws<RequestHandlerNullException>(() => new AwesomeRequestTwo(requestHandler));
        //Assert
        Assert.Equal("requestHandler", exception.ParamName);
    }

    // await GetResponseAsync "Hello World! Handled AwesomeRequestHandlerTwo" 
    [Fact]
    public async Task GetResponse_ShouldReturnHelloWorldHandledAwesomeRequestHandlerTwo()
    {
        //Arrange
        var requestHandler = new AwesomeRequestHandlerTwo();
        var request = new AwesomeRequestTwo(requestHandler);
        //Act
        var response = await request.GetResponseAsync();
        //Assert
        Assert.Equal("Hello World! Handled AwesomeRequestHandlerTwo", response);
    }

    //GetResponseAsync varify call dispatcher.DispatchAsync when RequestHandler is null
    [Fact]
    public async Task GetResponse_ShouldCallDispatcherDispatchAsync_WhenRequestHandlerIsNull()
    {
        //Arrange
        var dispatcher = new Mock<IDispatcher>();
        var request = new AwesomeRequestTwo(dispatcher.Object);
        //Act
        await request.GetResponseAsync();
        //Assert
        dispatcher.Verify(d => d.DispatchAsync(request, default), Times.Once);
    }

    //GetResponseAsync throw DispatcherNullException when RequestHundler and Dispatcher is null
    [Fact]
    public async Task GetResponse_ShouldThrowDispatcherNullException_WhenRequestHandlerAndDispatcherIsNull()
    {
        //Arrange
        var request = new AwesomeRequestTwo();
        //Act
        var exception = await Assert.ThrowsAsync<Dispatching.Exceptions.DispatcherNullException>(() => request.GetResponseAsync());
        //Assert
        Assert.Equal("Dispatcher", exception.ParamName);
    }

}
