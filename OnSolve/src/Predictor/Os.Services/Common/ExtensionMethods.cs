using System.Collections.Generic;
using System.Linq;
using System.Text;
using Os.Services.Common.Messages;

namespace Os.Services.Common
{
    public static class ExtensionMethods
    {
        public static bool IsBlank(this string value)
        {
            return string.IsNullOrWhiteSpace(value);
        }

        public static bool IsAValidCountryCode(this string value)
        {
            return !value.IsBlank() && Constants.CountryCodes.Any(x => x == value.ToUpper());
        }
        
        public static string AsText(this IEnumerable<IMessageItem> messages)
        {
            var allMessages = new StringBuilder();
            messages.ToList().ForEach(x => allMessages.AppendLine(x.Message));
            
            return allMessages.ToString();
        }
    }
}