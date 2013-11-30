using System;
using System.Collections.Generic;

namespace BiDictionary
{
    class BiDictionary<K1, K2, T>
        where K1 : class
        where K2 : class
    {
        private Dictionary<K1, HashSet<T>> first;
        private Dictionary<K2, HashSet<T>> second;

        public BiDictionary()
        {
            this.first = new Dictionary<K1, HashSet<T>>();
            this.second = new Dictionary<K2, HashSet<T>>();
        }

        public void Add(K1 key1, K2 key2, T value)
        {
            AddKeyToFirst(key1, value);
            AddKeyToSecond(key2, value);
        }

        private void AddKeyToFirst(K1 key, T value)
        {
            if (this.ContainsFirstKey(key) == true)
            {
                this.first[key].Add(value);
            }
            else
            {
                this.first.Add(key, new HashSet<T>() { value });
            }
        }

        private void AddKeyToSecond(K2 key, T value)
        {
            if (this.ContainsSecondKey(key) == true)
            {
                this.second[key].Add(value);
            }
            else
            {
                this.second.Add(key, new HashSet<T>() { value });
            }
        }

        public IEnumerable<T> Find(Object obj)
        {
            if (obj as K1 == obj as K2)
            {
                var key1 = obj as K1;
                var key2 = obj as K2;
                if (this.ContainsFirstKey(key1) == false &&
                    this.ContainsSecondKey(key2) == false)
                {
                    throw new InvalidOperationException("Key does not exist!");
                }
                else if (this.ContainsFirstKey(key1) != false &&
                         this.ContainsSecondKey(key2) == false)
                {
                    return first[key1];
                }
                else
                {
                    return second[key2];
                }
            }
            else if (obj is K1)
            {
                var key = obj as K1;
                if (this.ContainsFirstKey(key) == false)
                {
                    throw new InvalidOperationException("Key does not exist!");
                }
                else
                {
                    return first[key];
                }
            }
            else
            {
                var key = obj as K2;
                if (this.ContainsSecondKey(key) == false)
                {
                    throw new InvalidOperationException("Key does not exist!");
                }
                else
                {
                    return second[key];
                }
            }
        }

        public IEnumerable<T> Find(K1 key1, K2 key2)
        {
            if (this.ContainsKeys(key1, key2) == false)
            {
                throw new InvalidOperationException("Keys does not exist!");
            }
            else
            {
                HashSet<T> result = new HashSet<T>(this.first[key1]);
                result.IntersectWith(second[key2]);

                return result;
            }
        }

        public bool ContainsKeys(K1 key1, K2 key2)
        {
            bool result = this.ContainsFirstKey(key1) &&
                          this.ContainsSecondKey(key2);
            return result;
        }

        private bool ContainsFirstKey(K1 key)
        {
            return this.first.ContainsKey(key);
        }

        private bool ContainsSecondKey(K2 key)
        {
            return this.second.ContainsKey(key);
        }
    }
}
