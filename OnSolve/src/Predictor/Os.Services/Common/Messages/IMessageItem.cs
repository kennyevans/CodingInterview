namespace Os.Services.Common.Messages
{
    public enum MessageLevel
    {
        Error,
        Warning,
        Information
    }
    
    public interface IMessageItem
    {
        string Code { get; set; }
        string Definition { get; set; }
        string Message { get; }
        MessageLevel MessageLevel { get; set; }

        bool IsError { get; }
        bool IsWarning { get; }
        bool IsInformation { get; }

        string ToString();
    }
}