using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Globalization;
using System.Linq;

namespace Os.Services.Common.Messages
{
    public abstract class MessageItemBase : IMessageItem
    {
        protected static readonly ReadOnlyCollection<object> EmptyParameters = new List<object>().AsReadOnly();

        protected MessageItemBase(string code, string definition, MessageLevel messageLevel)
        {
            Code = code;
            Definition = definition;
            MessageLevel = messageLevel;
            Parameters = EmptyParameters;
        }
        
        protected MessageItemBase(string code, string definition, MessageLevel messageLevel, params object[] parameters)
        {
            Code = code;
            Definition = definition;
            MessageLevel = messageLevel;
            
            if (parameters == null || parameters.Length == 0)
            {
                this.Parameters = EmptyParameters;
            }
            else
            {
                List<object> objectList = new List<object>(parameters.Length);
                foreach (object parameter in parameters)
                    objectList.Add(parameter.ToString());
                this.Parameters = objectList.AsReadOnly();
            }
        }

        public string Code { get; set; }
        public string Definition { get; set; }
        public string Message => ToString();
        public IList<object> Parameters { get; private set; }

        public MessageLevel MessageLevel { get; set; }

        public bool IsError => MessageLevel == MessageLevel.Error;
        public bool IsWarning => MessageLevel == MessageLevel.Warning;
        public bool IsInformation => MessageLevel == MessageLevel.Information;

        public override string ToString()
        {
            return string.Format((IFormatProvider) CultureInfo.CurrentCulture, this.Definition, this.Parameters.ToArray());
        }
    }
}