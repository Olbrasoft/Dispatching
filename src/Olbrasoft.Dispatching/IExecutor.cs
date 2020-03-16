using System.Threading;
using System.Threading.Tasks;

namespace Olbrasoft.Dispatching
{
    public interface IExecutor<TResult>
    {
        Task<TResult> ExecuteAsync(IRequest<TResult> query, CancellationToken token);
    }
}