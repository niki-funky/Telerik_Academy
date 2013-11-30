
namespace HashSet
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using HashTable;

    public class HashSet<T>
    {
        HashTable<int, T> hashTable;

        public HashSet()
        {
            this.hashTable = new HashTable<int, T>();
        }

        // methods
        public void Add(T value)
        {
            hashTable.Add(GetKey(value), value);
        }

        public void Remove(T value)
        {
            hashTable.Remove(GetKey(value));
        }

        public T Find(T value)
        {
            return hashTable.Find(GetKey(value));
        }

        public bool Contains(T value)
        {
            return hashTable.Contains(GetKey(value));
        }

        public int Count
        {
            get
            {
                return hashTable.Count;
            }
        }

        public void Clear()
        {
            hashTable.Clear();
        }
        
        public void UnionWith(IEnumerable<T> other)
        {
            if (other == null)
            {
                throw new ArgumentNullException("Collection can not be null!");
            }

            foreach (T item in other)
            {
                var key = GetKey(item);
                if (!hashTable.Contains(key))
                {
                    hashTable.Add(key, item);
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
            foreach (T item in other)
            {
                var key = GetKey(item);
                if (hashTable.Contains(key))
                {
                    newHashTable.Add(key,item);
                }
            }
            hashTable = newHashTable;
        }

        public int GetKey(T value)
        {
            int result;
            result = 91 + value.GetHashCode();

            return result;
        }
    }
}
