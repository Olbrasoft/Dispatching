using MediatR;

namespace Dispatching.Benchmarks;

public class AwesomeRequestHandler : IRequestHandler<AwesomeRequest, string>, Olbrasoft.Dispatching.IRequestHandler<AwesomeRequest, string>
{
    public Task<string> Handle(AwesomeRequest request, CancellationToken cancellationToken)
    {
        return Task.FromResult("Hello World");
    }

    public Task<string> HandleAsync(AwesomeRequest request, CancellationToken token)
    {
        return Task.FromResult("Hello World");

    }
}