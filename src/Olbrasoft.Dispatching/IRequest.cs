namespace Olbrasoft.Dispatching
{
    public interface IRequest { }

    public interface IRequest<TResult> : IRequest
    {
    }
}