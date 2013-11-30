using System;
using System.Collections.Generic;
using System.Linq;
using Wintellect.PowerCollections;

namespace OrderedBag
{
    class Program
    {
        static void Main(string[] args)
        {
            int items = 500010;
            int ranges = 10000;
            int priceRange = 200000;

            OrderedBag<Product> orderedBag = new OrderedBag<Product>();

            for (int i = 1; i < items; i++)
            {
                orderedBag.Add(new Product("P", i));
            }
            for (int i = 0; i < ranges; i++)
            {
                var result = orderedBag.Range(new Product("P", priceRange), true,
                    new Product("P", priceRange + 20000), true);

                if (result.Count == 0)
                {
                    Console.WriteLine("No products found.");
                }

                List<Product> collection = new List<Product>();
                for (int j = 0; j < 20 && i < result.Count; j++)
                {
                    collection.Add(result[j]);
                }

                Console.WriteLine("Collection contains {0} items. ", collection.Count);
            }
        }
    }
}
