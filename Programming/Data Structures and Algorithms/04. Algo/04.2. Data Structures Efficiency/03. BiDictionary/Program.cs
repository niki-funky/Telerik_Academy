using System;
using System.Linq;

namespace BiDictionary
{
    // 03. Implement a class BiDictionary<K1,K2,T> that allows adding 
    // triples {key1, key2, value} and fast search by key1, key2 or 
    // by both key1 and key2. Note: multiple values can be stored for given key.

    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                const int NumberOfItems = 10;
                BiDictionary<string, string, int> collection =
                    new BiDictionary<string, string, int>();

                for (int i = 0; i < NumberOfItems; i++)
                {
                    collection.Add("K1" + i, "K2" + i, i);
                }

                for (int i = 0; i < NumberOfItems; i++)
                {
                    collection.Add("K1" + i, "K2" + i, i * 7);
                }

                Console.WriteLine(collection.Find("K29").Count());
                Console.WriteLine(collection.Find("K19", "K29").Count());
                Console.WriteLine(collection.Find("K199").Count());
            }
            catch (InvalidOperationException iex)
            {
                Console.WriteLine(iex.Message);
            }
        }
    }
}
