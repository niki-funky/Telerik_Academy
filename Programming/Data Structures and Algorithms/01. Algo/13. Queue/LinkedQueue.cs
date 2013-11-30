using System;
using System.Linq;

namespace LinkedQueue
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    // 13. Implement the ADT queue as dynamic linked list. 
    // Use generics (LinkedQueue<T>) to allow storing different data types in the queue.

    class LinkedQueue<T> where T : IComparable<T>
    {
        private LinkedQueueItem<T> head;
        private LinkedQueueItem<T> tail;

        public int Count { get; private set; }

        public LinkedQueue()
        {
            this.head = null;
            this.tail = null;
            this.Count = 0;
        }

        public void Enqueue(T value)
        {
            if (this.tail == null)
            {
                this.tail = new LinkedQueueItem<T>(value);
                this.head = tail;
            }
            else
            {
                LinkedQueueItem<T> newItem = new LinkedQueueItem<T>(value, null, this.tail);
                this.tail.Next = newItem;
                this.tail = newItem;
            }
            this.Count++;
        }

        public T Dequeue()
        {
            if (this.Count > 0)
            {
                T first = head.Value;
                if (this.head.Next == null)
                {
                    this.head = null;
                    this.tail = null;
                }
                else
                {
                    this.head = head.Next;
                    this.head.Previous = null;
                }
                this.Count--;
                return first;
            }
            else
            {
                throw new NullReferenceException("Queue is empty!");
            }
        }

        public T Peek()
        {
            if (this.Count > 0)
            {
                T first = this.head.Value;
                return first;
            }
            else
            {
                throw new NullReferenceException("Queue is empty!");
            }
        }

        public bool Contains(T value)
        {
            LinkedQueueItem<T> currentItem = this.head;
            while (currentItem != null)
            {
                if (currentItem.Value.Equals(value))
                {
                    return true;
                }
                currentItem = currentItem.Next;
            }
            return false;
        }

        public void Clear()
        {
            this.Count = 0;
            this.head = null;
            this.tail = null;
        }

        public T[] ToArray()
        {
            T[] array = new T[this.Count];
            for (int i = 0; i < this.Count; i++)
            {
                array[i] = this[i];
            }
            return array;
        }

        public T this[int index]
        {
            get
            {
                int counter = 0;
                if (index >= this.Count)
                {
                    throw new IndexOutOfRangeException(String.Format("Invalid index: {0}.", index));
                }
                else
                {
                    LinkedQueueItem<T> currentElement = this.head;
                    while (counter < index)
                    {
                        currentElement = currentElement.Next;
                        counter++;
                    }

                    return currentElement.Value;
                }
            }
        }
    }
}
