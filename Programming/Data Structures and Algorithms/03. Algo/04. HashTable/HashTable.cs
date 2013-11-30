
namespace HashTable
{
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Linq;

    public class HashTable<K, T> : IEnumerable<KeyValuePair<K, T>>
    {
        private double factor = 0.75;
        private LinkedList<KeyValuePair<K, T>>[] linkedList;

        public int Count { get; private set; }

        public List<K> Keys
        {
            get
            {
                List<K> keys = new List<K>();
                for (int i = 0; i < this.linkedList.Length; i++)
                {
                    if (this.linkedList[i] != null)
                    {
                        var next = this.linkedList[i].First;
                        while (next != null)
                        {
                            keys.Add(next.Value.Key);
                            next = next.Next;
                        }
                    }
                }
                return keys;
            }
            private set { }
        }

        public HashTable()
        {
            this.linkedList = new LinkedList<KeyValuePair<K, T>>[16];
            this.Count = 0;
        }

        // methods
        public void Add(K key, T value)
        {
            int length = this.linkedList.Length;
            if (this.Count >= length * factor)
            {
                DoubleCapacity();
            }

            int index = GetArrayPosition(key);
            if (this.linkedList[index] == null)
            {
                this.linkedList[index] = new LinkedList<KeyValuePair<K, T>>();
                this.Count++;
            }

            var next = this.linkedList[index].First;
            while (next != null)
            {
                if (next.Value.Key.Equals(key))
                {
                    throw new ArgumentException("Key must be unique!");
                }
                next = next.Next;
            }
            this.linkedList[index].AddLast(new KeyValuePair<K, T>(key, value));
        }

        public void Remove(K key)
        {
            int index = GetArrayPosition(key);
            if (this.linkedList[index] == null)
            {
                throw new ArgumentException("There is no such key!");
            }
            else
            {
                bool isFound = false;
                var next = this.linkedList[index].First;
                while (next != null)
                {
                    if (next.Value.Key.Equals(key))
                    {
                        this.linkedList[index].Remove(next);
                        isFound = true;
                        break;
                    }
                    next = next.Next;
                }
                if (this.linkedList[index].First == null)
                {
                    this.Count -= 1;
                }
                if (isFound == false)
                {
                    throw new ArgumentException("There is no such key!");
                }
            }
        }

        public T Find(K key)
        {
            int index = GetArrayPosition(key);
            if (this.linkedList[index] == null)
            {
                throw new ArgumentException("There is no such key!");
            }
            else
            {
                var next = this.linkedList[index].First;
                while (next != null)
                {
                    if (next.Value.Key.Equals(key))
                    {
                        return next.Value.Value;
                    }
                    next = next.Next;
                }
                throw new ArgumentException("There is no such key!");
            }
        }

        public bool Contains(K key)
        {
            if (key == null)
            {
                return false;
            }

            int index = GetArrayPosition(key);
            if (this.linkedList[index] != null)
            {
                var next = this.linkedList[index].First;
                while (next != null)
                {
                    if (next.Value.Key.Equals(key))
                    {
                        return true;
                    }
                    next = next.Next;
                }
            }
            return false;
        }

        public void Clear()
        {
            if (this.Count == 0)
            {
                return;
            }
            for (int i = 0; i < this.linkedList.Length; i++)
            {
                this.linkedList[i] = new LinkedList<KeyValuePair<K, T>>();
            }
            this.Count = 0;
        }

        public T this[K key]
        {
            get
            {
                return Find(key);
            }
            set
            {
                int index = GetArrayPosition(key);
                if (this.linkedList[index] == null)
                {
                    throw new ArgumentException("There is no such key!");
                }
                else
                {
                    bool isFound = false;
                    var next = this.linkedList[index].First;
                    while (next != null)
                    {
                        if (next.Value.Key.Equals(key))
                        {
                            LinkedListNode<KeyValuePair<K, T>> newNode =
                                new LinkedListNode<KeyValuePair<K, T>>(new KeyValuePair<K, T>(key, value));
                            this.linkedList[index].AddAfter(next, newNode);
                            this.linkedList[index].Remove(next);
                            isFound = true;
                            break;
                        }
                        next = next.Next;
                    }
                    if (isFound == false)
                    {
                        throw new ArgumentException("There is no such key!");
                    }
                }
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            // Call the generic version of the method
            return this.GetEnumerator();
        }

        public IEnumerator<KeyValuePair<K, T>> GetEnumerator()
        {
            for (int i = 0; i < this.linkedList.Length; i++)
            {
                if (this.linkedList[i] != null)
                {
                    var next = this.linkedList[i].First;
                    while (next != null)
                    {
                        yield return next.Value;
                        next = next.Next;
                    }
                }
            }
        }

        // additional methods
        private void DoubleCapacity()
        {
            int newCapacity = linkedList.Length * 2;
            LinkedList<KeyValuePair<K, T>>[] newLinkedList =
                new LinkedList<KeyValuePair<K, T>>[newCapacity];
            for (int i = 0; i < this.linkedList.Length; i++)
            {
                newLinkedList[i] = this.linkedList[i];
            }

            this.linkedList = newLinkedList;
        }

        protected int GetArrayPosition(K key)
        {
            int position = key.GetHashCode() % this.linkedList.Length;

            return Math.Abs(position);
        }
    }
}
