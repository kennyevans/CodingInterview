using System.Collections.Generic;

namespace Os.Services.Common.Messages
{
    public interface IMessages : IList<IMessageItem>, IText
    {
        bool HasMessages { get; }
    }
}