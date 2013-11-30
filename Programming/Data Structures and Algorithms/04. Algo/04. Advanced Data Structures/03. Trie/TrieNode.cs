using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;

namespace Trie
{
    public class TrieNode : IComparable<TrieNode>
    {
        public TrieNode Parent { get; private set; }
        public ConcurrentDictionary<char, TrieNode> Children { get; private set; }
        public char Char { get; private set; }
        public int WordCount { get; private set; }

        public TrieNode(TrieNode parent, char c)
        {
            this.Char = c;
            this.WordCount = 0;
            this.Parent = parent;
            this.Children = new ConcurrentDictionary<char, TrieNode>();
        }

        public void AddWord(string word, int index = 0)
        {
            if (index < word.Length)
            {
                char key = word[index];
                if (char.IsLetter(key))
                {
                    if (!Children.ContainsKey(key))
                    {
                        Children.TryAdd(key, new TrieNode(this, key));
                    }
                    Children[key].AddWord(word, index + 1);
                }
                else
                {
                    AddWord(word, index + 1);
                }
            }
            else
            {
                // skip empty words
                if (Parent != null)
                {
                    lock (this)
                    {
                        WordCount++;
                    }
                }
            }
        }

        public int GetCount(string word, int index = 0)
        {
            if (index < word.Length)
            {
                char key = word[index];
                if (!Children.ContainsKey(key))
                {
                    return -1;
                }

                return Children[key].GetCount(word, index + 1);
            }
            else
            {
                return WordCount;
            }
        }

        public void GetWordCount(ref List<TrieNode> searched, 
                    ref int distinctWordCount, ref int totalWordCount)
        {
            if (WordCount > 0)
            {
                distinctWordCount++;
                totalWordCount += WordCount;
            }
            if (WordCount > searched[0].WordCount)
            {
                searched[0] = this;
                searched.Sort();
            }
            foreach (char key in Children.Keys)
            {
                Children[key].GetWordCount(ref searched, 
                    ref distinctWordCount, ref totalWordCount);
            }
        }

        public override string ToString()
        {
            if (Parent == null)
            {
                return string.Empty;
            }
            else
            {
                return Parent.ToString() + Char;
            }
        }

        public int CompareTo(TrieNode other)
        {
            var otherCount = other.WordCount;
            return this.WordCount.CompareTo(otherCount);
        }
    }
}
