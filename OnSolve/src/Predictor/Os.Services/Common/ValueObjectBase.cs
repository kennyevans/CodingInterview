using Os.Services.Common.Messages;

namespace Os.Services.Common
{
    public abstract class ValueObjectBase
    {
        protected ValueObjectBase()
        {
            Messages = new ServiceMessagesBase();
        }
        
        public ServiceMessagesBase Messages { get; set; }

        public bool AtLeastError => Messages.AtLeastError();

        public bool AnyMessages => Messages.HasMessages;
    }
}