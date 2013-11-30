
namespace HashSet
{
    using HashTable;
    using System;
    using System.Collections;
    using System.Collections.Generic;

    internal class HashSet<T>
    {
        private HashTable<int, T> hashTable;

        public int Count
        {
            get
            {
                int count = this.hashTable.Count;
                return count;
            }
        }

        public HashSet()
        {
            this.hashTable = new HashTable<int, T>();
        }

        public void Add(T value)
        {
            this.hashTable.Add(this.GetKey(value), value);
        }

        public void Remove(T value)
        {
            this.hashTable.Remove(this.GetKey(value));
        }

        public void Clear()
        {
            this.hashTable.Clear();
        }

        public bool Contains(T value)
        {
            return this.hashTable.Contains(this.GetKey(value));
        }

        public T Find(T value)
        {
            return this.hashTable.Find(this.GetKey(value));
        }

        public void UnionWith(IEnumerable<T> other)
        {
            if (other == null)
            {
                throw new ArgumentNullException("Collection can not be null!");
            }

            foreach (var item in other)
            {
                int key = this.GetKey(item);
                if (!this.hashTable.Contains(key))
                {
                    this.hashTable.Add(key, item);
                }
            }
        }

        public void Intersect(IEnumerable<T> other)
        {
            if (other == null)
            {
                throw new ArgumentNullException("Collection can not be null!");
            }

            HashTable<int, T> newHashTable = new HashTable<int, T>();
            foreach (var item in other)
            {
                int key = this.GetKey(item);
                if (this.hashTable.Contains(key))
                {
                    newHashTable.Add(key, item);
                }
            }

            this.hashTable = newHashTable;
        }

        public int GetKey(T value)
        {
            int result = 91 + value.GetHashCode();
            return result;
        }
    }
}