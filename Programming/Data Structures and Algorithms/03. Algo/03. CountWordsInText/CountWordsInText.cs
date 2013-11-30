
namespace CountWordsInText
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text.RegularExpressions;

    class CountWordsInText
    {
        static void Main(string[] args)
        {
            var fileName = @"..\..\words.txt";
            var pattern = @"[^\W\d](\w|[-']{1,2}(?=\w))*";
            string line;
            IDictionary<string, int> dictionary = new Dictionary<string, int>();

            using (System.IO.StreamReader reader = new System.IO.StreamReader(fileName))
            {
                while ((line = reader.ReadLine()) != null)
                {
                    var words = Regex.Matches(line, pattern);
                    foreach (Match match in words)
                    {
                        string word = match.Value.ToLower();
                        if (!dictionary.ContainsKey(word))
                        {
                            dictionary[word] = 1;
                        }
                        else
                        {
                            dictionary[word]++;
                        }
                    }
                }

                foreach (var pair in dictionary.OrderBy(x => x.Value))
                {
                    Console.WriteLine(pair.Key + " -> " + pair.Value);
                }

            }
        }
    }
}
