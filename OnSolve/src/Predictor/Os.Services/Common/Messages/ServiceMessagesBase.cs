using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Os.Services.Common.Messages
{
    public class ServiceMessagesBase : IServiceMessagesBase
    {
        private readonly List<IMessageItem> _innerMessageItems;

        public ServiceMessagesBase()
        {
            _innerMessageItems = new List<IMessageItem>();
        }

        public bool AtLeastError()
        {
            return _innerMessageItems.Any(x => x.IsError);
        }

        public bool HasMessages => _innerMessageItems.Any();

        public string AsText()
        {
            var messages = new StringBuilder();
            if (this.HasMessages) _innerMessageItems.ForEach(x => messages.AppendLine(x.Message));
            return messages.ToString();
        }

        IEnumerator<IMessageItem> IEnumerable<IMessageItem>.GetEnumerator()
        {
            return (this._innerMessageItems != null ? (IEnumerable<IMessageItem>)this._innerMessageItems : new IMessageItem[] { }).GetEnumerator();
        }

        public IEnumerator GetEnumerator()
        {
            return _innerMessageItems?.GetEnumerator() ?? (new IEnumerator[] { }).GetEnumerator();
        }

        public void Add(IMessageItem item)
        {
            this._innerMessageItems.Add(item);
        }

        public void Clear()
        {
            this._innerMessageItems.Clear();
        }

        public bool Contains(IMessageItem item)
        {
            return item != null &&
                   this._innerMessageItems.Any(x => x.Code == item.Code);
        }

        public void CopyTo(IMessageItem[] array, int arrayIndex)
        {
            this._innerMessageItems.CopyTo(array, arrayIndex);
        }

        public bool Remove(IMessageItem item)
        {
            return this._innerMessageItems.Remove(item);
        }

        public int Count => this._innerMessageItems.Count;
        public bool IsReadOnly => false;

        public int IndexOf(IMessageItem item)
        {
            return this._innerMessageItems.IndexOf(item);
        }

        public void Insert(int index, IMessageItem item)
        {
            this._innerMessageItems.Insert(index, item);
        }

        public void RemoveAt(int index)
        {
            this._innerMessageItems.RemoveAt(index);
        }

        public IMessageItem this[int index]
        {
            get
            {
                return this._innerMessageItems[index];
            }
            set
            {
                this._innerMessageItems[index] = value ?? throw new ArgumentNullException("value");
            }
        }
    }
}