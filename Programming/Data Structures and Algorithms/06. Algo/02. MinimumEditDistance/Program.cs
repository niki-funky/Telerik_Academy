using System;
using System.Linq;

namespace _02.MinimumEditDistance
{
    // 02. Write a program to calculate the "Minimum Edit Distance" (MED) 
    // between two words. MED(x, y) is the minimal sum of costs of edit operations
    // used to transform x to y. Sample costs are given below:
    // 
    // cost (replace a letter) = 1
    // cost (delete a letter) = 0.9
    // cost (insert a letter) = 0.8
    // Example: x = "developer", y = "enveloped" -> cost = 2.7 
    // delete ‘d’:  "developer" -> "eveloper", cost = 0.9
    // insert ‘n’:  "eveloper" -> "enveloper", cost = 0.8
    // replace ‘r’ -> ‘d’:  "enveloper" -> "enveloped", cost = 1

    using System;

    static class LevenshteinDistance
    {
        public static double Compute(string firstString, string secondString)
        {
            int n = firstString.Length;
            int m = secondString.Length;
            double[,] d = new double[n + 1, m + 1];

            var costOfDel = 0.9;
            var costOfIns = 0.8;
            var costOfSubs = 1.0;

            // Step 1
            if (n == 0)
            {
                return m;
            }

            if (m == 0)
            {
                return n;
            }

            // Step 2
            for (int i = 0; i <= n; i++)
            {
                d[i, 0] = i * costOfDel;
            }

            for (int j = 0; j <= m; j++)
            {
                d[0, j] = j * costOfIns;
            }

            // Step 3
            for (int i = 1; i <= n; i++)
            {
                //Step 4
                for (int j = 1; j <= m; j++)
                {
                    // Step 5                    
                    if (secondString[j - 1] == firstString[i - 1])
                    {
                        d[i, j] = d[i - 1, j - 1];

                    }
                    // Step 6
                    else
                    {
                        var deletion = d[i - 1, j] + costOfDel;
                        var insertion = d[i, j - 1] + costOfIns;
                        var substitution = d[i - 1, j - 1] + costOfSubs;

                        d[i, j] = Math.Min(
                            Math.Min(deletion, insertion),
                            substitution);
                    }
                }
            }
            // Step 7
            return d[n, m];
        }
    }

    class Program
    {
        static void Main()
        {
            Console.WriteLine(LevenshteinDistance.Compute("developer", "enveloped"));
            Console.WriteLine(LevenshteinDistance.Compute("developer", "eveloper"));
            Console.WriteLine(LevenshteinDistance.Compute("eveloper", "enveloper"));
            Console.WriteLine(LevenshteinDistance.Compute("enveloper", "enveloped"));
        }
    }
}
