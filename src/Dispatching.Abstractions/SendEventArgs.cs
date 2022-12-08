namespace Olbrasoft.Dispatching;

public class SendEventArgs : EventArgs
{
    public object Request { get; }
    public object? Response { get; }

    public SendEventArgs(object request, object? response = null)
    {
        if (request is null)
            throw new RequestNullException();

        Request = request;
        Response = response;
    }
}