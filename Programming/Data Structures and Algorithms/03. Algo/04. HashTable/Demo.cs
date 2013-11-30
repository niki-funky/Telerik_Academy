
namespace HashTable
{
    using System;
    using System.Linq;

    class Demo
    {
        static void Main(string[] args)
        {
            try
            {
                HashTable<string, int> hashTable = new HashTable<string, int>();

                hashTable.Add("pesho", 1);
                hashTable.Add("gosho", 5);
                hashTable.Add("misho", 2);
                hashTable.Add("sasho", 3);
                Console.WriteLine("Count is : {0}", hashTable.Count);

                hashTable.Remove("sasho");
                Console.WriteLine("Count is : {0}", hashTable.Count);

                Console.WriteLine(hashTable.Find("gosho"));
                Console.WriteLine(hashTable.Contains("gosho"));
                Console.WriteLine(hashTable["gosho"]);

                foreach (var item in hashTable)
                {
                    Console.WriteLine(item.Key + " -> " + item.Value);
                }

                for (int i = 0; i < 30; i++)
                {
                    hashTable.Add(i * 131 + "", i + 100);
                }
                Console.WriteLine("Count is : {0}", hashTable.Count);

                hashTable.Clear();
                Console.WriteLine("Count is : {0}", hashTable.Count);
                Console.WriteLine(hashTable.Find("gosho"));
            }
            catch (ArgumentException aex)
            {
                Console.WriteLine(aex.Message);
            }
        }
    }
}
