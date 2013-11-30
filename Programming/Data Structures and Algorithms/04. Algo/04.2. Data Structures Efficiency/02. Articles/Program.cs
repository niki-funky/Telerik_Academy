using System;
using System.Linq;
using Wintellect.PowerCollections;

namespace Articles
{
    // 02. A large trade company has millions of articles, each described by barcode,
    // vendor, title and price. Implement a data structure to store them that allows 
    // fast retrieval of all articles in given price range [x…y]. 
    // Hint: use OrderedMultiDictionary<K,T> from Wintellect's Power Collections for .NET. 

    public class Program
    {
        public static void Main(string[] args)
        {
            const int NumberOfItems = 1000000;

            OrderedMultiDictionary<double, Article> collection =
                new OrderedMultiDictionary<double, Article>(true);

            for (int i = 0; i < NumberOfItems; i++)
            {
                Article article = new Article("b" + i, "v" + i, "t" + i, i * 1.1);
                collection.Add(article.Price, article);
            }

            var result = collection.Range(150000, true, 150020, true);

            Console.WriteLine(result.Count);
        }
    }
}
