using System;

class SubsetSums
{
    //You are given a list of N numbers. Write a program that counts all non-empty subsets from this list,
    //which have sum of their elements exactly S.
    //Example: if you have a list with 4 elements: { 1, 2, 3, 4 } 
    //and you are searching the number of non-empty subsets which sum is 4, the answer will be 2. 
    //The subsets are: { 1, 3 } and { 4 }.

    static void Main()
    {
        //variables
        long S = long.Parse(Console.ReadLine());
        int N = int.Parse(Console.ReadLine());
        long[] setOfNumbers = new long[N];
        int subsets = 0;

        for (int i = 0; i < N; i++)
        {
            long.TryParse(Console.ReadLine(), out setOfNumbers[i]);
        }

        //expressions
        for (int i = 1; i <= Math.Pow(2, N) - 1; i++)
        {
            long sum = 0;
            long member;
            for (int j = 0; j < N; j++)
            {
                member = ((i >> j) & 1) * setOfNumbers[j];
                sum += member;
            }
            if (sum == S)
            {
                subsets++;
            }
        }

        Console.WriteLine(subsets);
    }
}
