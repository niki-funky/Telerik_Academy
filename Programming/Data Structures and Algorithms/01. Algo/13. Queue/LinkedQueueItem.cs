namespace LinkedQueue
{
    using System;
    using System.Linq;

    class LinkedQueueItem<T>
    {
        public T Value { get; private set; }

        public LinkedQueueItem<T> Next { get; set; }

        public LinkedQueueItem<T> Previous { get; set; }

        public LinkedQueueItem(T value)
            : this(value, null, null)
        {
        }

        public LinkedQueueItem(T value, LinkedQueueItem<T> nextValue, LinkedQueueItem<T> prevValue)
        {
            this.Value = value;
            this.Next = nextValue;
            this.Previous = prevValue;
        }
    }
}
