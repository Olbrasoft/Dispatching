using System.Threading;
using System.Threading.Tasks;
using Olbrasoft.Dispatching.Abstractions;

namespace Olbrasoft.Dispatching
{
    public interface IExecutor<TResult> : IHandler
    {
        Task<TResult> ExecuteAsync(IRequest<TResult> query, CancellationToken token);
    }
}