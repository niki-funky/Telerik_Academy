
namespace ExtractElements
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    class ExtractElements
    {
        static void Main(string[] args)
        {
            string[] array = { "C#", "SQL", "PHP", "PHP", "SQL", "SQL" };
            Dictionary<string, int> dictionary = new Dictionary<string, int>();

            foreach (var item in array)
            {
                if (!dictionary.ContainsKey(item))
                {
                    dictionary[item] = 1;
                }
                else
                {
                    dictionary[item]++;
                }
            }

            foreach (var item in dictionary)
            {
                if (item.Value % 2 == 1)
                {
                    Console.WriteLine(item.Key);
                }
            }
        }
    }
}
