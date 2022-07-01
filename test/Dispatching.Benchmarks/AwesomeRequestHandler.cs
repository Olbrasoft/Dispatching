using System.Threading;
using System.Threading.Tasks;

namespace Olbrasoft.Dispatching.Benchmarks
{
    public class AwesomeRequestHandler : IRequestHandler<AwesomeRequest, object>, MediatR.IRequestHandler<AwesomeRequest, object>
    {
        public async Task<object> Handle(AwesomeRequest request, CancellationToken cancellationToken)
        {
            return await Task.FromResult(new object());
        }

        public async Task<object> HandleAsync(AwesomeRequest request, CancellationToken token)
        {
            return await Task.FromResult(new object());
        }
    }
}