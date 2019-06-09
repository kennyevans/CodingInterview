namespace Os.Services.Common.Messages
{
    public interface IServiceMessagesBase : IMessages
    {
        bool AtLeastError();
    }
}