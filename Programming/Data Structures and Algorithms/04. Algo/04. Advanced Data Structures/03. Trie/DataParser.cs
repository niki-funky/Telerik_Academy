using System;
using System.IO;
using System.Linq;

namespace Trie
{
    public class DataParser
    {
        private const int LoopCount = 1;
        private readonly TrieNode root;
        private readonly string path;

        public DataParser(string path, ref TrieNode root)
        {
            this.root = root;
            this.path = path;
        }

        public void ParseData()
        {
            // fake large data set by parsing smaller file multiple times
            for (int i = 0; i < LoopCount; i++)
            {
                using (FileStream fstream = new FileStream(path, FileMode.Open, FileAccess.Read))
                {
                    using (StreamReader sreader = new StreamReader(fstream))
                    {
                        string line;
                        while ((line = sreader.ReadLine()) != null)
                        {
                            string[] chunks = line.Split(new char[] { ' ', '.', ',', ':', '!', ';', '?' });
                            foreach (string chunk in chunks)
                            {
                                if (!string.IsNullOrEmpty(chunk))
                                {
                                    root.AddWord(chunk.Trim());
                                }
                            }
                        }
                    }
                }
            }
        }
    }
}
