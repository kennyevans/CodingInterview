using Os.Services.Common.Messages;

namespace Os.Services.Text
{
    public class CurrencyExchangePredictorMessages
    {
        /// <summary>
        /// '{0}' is mandatory.
        /// </summary>
        public class Mandatory : MessageItemBase
        {
            protected static readonly string Definition = "'{0}' is mandatory.";

            public Mandatory(string fieldName, MessageLevel messageLevel = MessageLevel.Error)
                        : base("OS-0001", Definition, messageLevel, fieldName) { }
        }
        
        /// <summary>
        /// '{0}' is not a valid '{1}' value.
        /// </summary>
        public class NotAValidValue : MessageItemBase
        {
            protected static readonly string Definition = "'{0}' is not a valid '{1}' value.";
            
            public NotAValidValue(string fieldName, object value, MessageLevel messageLevel = MessageLevel.Error)
                            : base("OS-0002", Definition, messageLevel, value, fieldName) { }
        }

        /// <summary>
        /// Internal error occured. Please contact support@operation.org for consult.
        /// </summary>
        public class InternalError : MessageItemBase {
            protected static readonly string Definition = "Internal error occured. Please contact mir3support@onsolve.com for consult.";

            public InternalError(MessageLevel messageLevel = MessageLevel.Error)
                : base("OS-0003", Definition, messageLevel) { }
         }
    }
}