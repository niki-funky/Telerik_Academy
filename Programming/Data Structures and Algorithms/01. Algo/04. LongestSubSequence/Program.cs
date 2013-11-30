
namespace LongestSubSequence
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    // 04. Write a method that finds the longest subsequence of equal numbers
    // in given List<int> and returns the result as new List<int>. Write 
    // a program to test whether the method works correctly.

    class LongestSubSequence
    {
        private static List<int> sequence =
            new List<int> { 1, 0, -2, -2, 3, 3, 3, -4, -4, -4, -4, 5, 5, 5, 5, 5 };

        private static List<int> FindLongest(List<int> collection)
        {
            List<int> currSubSequence = new List<int>();
            List<int> longestSubSequence = new List<int>();
            var current = collection.First();
            currSubSequence.Add(current);

            var currentCount = 0;
            var longestCount = 0;
            for (int i = 1; i < collection.Count; i++)
            {
                if (collection[i] == current)
                {
                    currSubSequence.Add(collection[i]);
                    currentCount++;
                }
                else
                {
                    if (currentCount > longestCount)
                    {
                        longestCount = currentCount;
                        longestSubSequence = currSubSequence;
                    }
                    currSubSequence.Clear();
                    currentCount = 0;
                    current = collection[i];
                    currSubSequence.Add(current);
                }
            }

            return longestSubSequence;
        }

        public static void Main(string[] args)
        {
            var subSequence = FindLongest(sequence);
            var listAsString = string.Join(",", subSequence.ToArray());

            Console.WriteLine("Longest subsequence is: " + "{ " + listAsString + " }");
        }
    }
}
