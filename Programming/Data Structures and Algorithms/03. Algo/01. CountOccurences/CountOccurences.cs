
namespace CountOccurences
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    class CountOccurences
    {
        static void Main(string[] args)
        {
            double[] array = new double[] { 3, 4, 4, -2.5, 3, 3, 4, 3, -2.5 };
            IDictionary<double, int> dictionary = new Dictionary<double, int>();

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
            foreach (var pair in dictionary)
            {
                Console.WriteLine(pair.Key + " -> " + pair.Value);
            }
        }
    }
}
