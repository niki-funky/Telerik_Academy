using System;
using System.Collections.Generic;
using System.IO;

namespace Trie
{
    public class Program
    {
        public static void Main(string[] args)
        {
            string path = @"..\..\text.txt";
            Console.WriteLine("Counting words...");

            // read the text
            DateTime startTime = DateTime.Now;
            TrieNode root = new TrieNode(null, '?');
            DataParser newReader = new DataParser(path, ref root);
            newReader.ParseData();

            DateTime stopTime = DateTime.Now;
            Console.WriteLine("Input data processed in {0} secs.",
                new TimeSpan(stopTime.Ticks - startTime.Ticks).TotalSeconds);
            Console.WriteLine();
            Console.WriteLine("List of found words:");

            // read the words to be searched
            List<TrieNode> wordsToSearch = new List<TrieNode>();
            GetWords(wordsToSearch);

            int distinctWordCount = 0;
            int totalWordCount = 0;
            root.GetWordCount(ref wordsToSearch, ref distinctWordCount, ref totalWordCount);
            wordsToSearch.Reverse();
            foreach (TrieNode node in wordsToSearch)
            {
                Console.WriteLine("{0} - {1} times", node.ToString(), node.WordCount);
            }

            Console.WriteLine();
            Console.WriteLine("{0} words counted", totalWordCount);
            Console.WriteLine("{0} distinct words found", distinctWordCount);
            Console.WriteLine();
            Console.WriteLine("done.");
        }

        private static void GetWords(List<TrieNode> words)
        {
            var fileName = @"..\..\words.txt";
            string line;
            using (StreamReader reader = new StreamReader(fileName))
            {
                while ((line = reader.ReadLine()) != null)
                {
                    TrieNode node = new TrieNode(null, '?');
                    node.AddWord(line);
                    words.Add(node);
                }
            }
        }
    }
}