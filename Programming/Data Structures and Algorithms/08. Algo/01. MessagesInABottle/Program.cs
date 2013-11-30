using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace _01.MessagesInABottle
{
    class Program
    {
        static string message;
        static List<string> decoded = new List<string>();
        static Dictionary<string, string> ciphers = new Dictionary<string, string>();

        static void Main(string[] args)
        {
#if DEBUG
            Console.SetIn(new System.IO.StreamReader("../../input.txt")); // Runs locally only
#endif

            message = Console.ReadLine();
            var code = Console.ReadLine();

            var codes = Regex.Matches(code, @"(\D)(\d+)");
            foreach (Match cipher in codes)
            {
                ciphers[cipher.Groups[1].Value] = cipher.Groups[2].Value;
            }

            Decode(message, string.Empty);

            decoded.Sort();

            // print result
            Console.WriteLine(decoded.Count);
            foreach (var msg in decoded)
            {
                Console.WriteLine(msg);
            }
        }

        static void Decode(string encoded, string decodedMessage)
        {
            if (encoded.Length == 0)
            {
                decoded.Add(decodedMessage);
            }
            else
            {
                foreach (var cipher in ciphers)
                {
                    if (encoded.StartsWith(cipher.Value))
                    {
                        Decode(
                            encoded.Substring(cipher.Value.Length),
                            decodedMessage + cipher.Key);
                    }
                }
            }
        }
    }
}
