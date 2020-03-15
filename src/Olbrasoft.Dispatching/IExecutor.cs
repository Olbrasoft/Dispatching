using System.Threading;
using System.Threading.Tasks;

namespace Olbrasoft.Dispatching
{
    public interface IExecutor<TResponse>
    {

        Task<TResponse> ExecuteAsync(IRequest<TResponse> request, CancellationToken token);
    }
}