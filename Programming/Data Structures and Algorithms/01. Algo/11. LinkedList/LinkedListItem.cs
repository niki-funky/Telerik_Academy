namespace LinkedList
{
    using System;
    using System.Linq;

    class LinkedListItem<T>
    {
        public T Value { get; private set; }
        public LinkedListItem<T> NextItem { get; set; }

        public LinkedListItem()
            : this(default(T), null)
        {
        }

        public LinkedListItem(T value, LinkedListItem<T> next)
        {
            this.Value = value;
            this.NextItem = next;
        }

        public LinkedListItem(T value)
        {
            this.Value = value;
            this.NextItem = null;
        }
    }
}
