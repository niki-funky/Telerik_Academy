using System;
using System.Linq;

namespace _01.CoinsProblem
{
    // 01. You are given a set of infinite number of coins (1, 2 and 5)
    // and end value – N. Write an algorithm that gives the number of 
    // coins needed so that the sum of the coins equals N. 
    // Example:
    // N = 33 => 6 coins x 5 + 1 coin x 2 + 1 coin x 1

    class Program
    {
        // The array 'minDenominations' stores in each cell, 
        // the minimum number of coins required to construct 
        // the amount denoted by the index of the cell.
        // The 'maxDenominations' coin stores the coin of largest denomination
        // that is used to construct the amount of the index.
        // The array 'result' stores the min number of coins
        // needed to construct the sum.
        private static void CalculateMinumCoins(
            int[] coins, int sum, int[] result)
        {
            int[] minDenominations = new int[sum];
            int[] maxDenominations = new int[sum];
            int currDenomination;

            minDenominations[0] = 0;
            maxDenominations[0] = 0;

            for (int i = 1; i < sum; i++)
            {
                int minDenomination = minDenominations[i - coins[0]];
                currDenomination = 1;

                for (int j = 2; j < coins.Length; j++)
                {
                    if (i - coins[j] >= 0 &&
                        minDenominations[i - coins[j]] < minDenomination)
                    {
                        minDenomination = minDenominations[i - coins[j]];
                        currDenomination = j;
                    }
                }

                minDenominations[i] = minDenomination + 1;
                maxDenominations[i] = currDenomination;
            }

            for (int i = 0; i < coins.Length; i++)
            {
                result[i] = 0;
            }

            while (sum > 0)
            {
                result[maxDenominations[sum - 1]] =
                    result[maxDenominations[sum - 1]] + 1;
                sum = sum - coins[maxDenominations[sum - 1]];
            }
        }

        static void Main(string[] args)
        {
            int target = 33;
            int[] coins = { 1, 2, 5 };
            int[] result = new int[target];

            CalculateMinumCoins(coins, target, result);

            for (int i = 0; i < result.Length; i++)
            {
                var res = result[i];
                if (res > 0)
                {
                    Console.WriteLine(res + (res > 1 ? " coins" : " coin")
                        + " x " + coins[i]);
                }
            }
        }
    }
}
