using System;
using System.Linq;

namespace _01.KnapsackProblem
{
    // 01. Write a program based on dynamic programming to solve the "Knapsack Problem":
    // you are given N products, each has weight Wi and costs Ci and a knapsack of 
    // capacity M and you want to put inside a subset of the products with highest 
    // cost and weight ≤ M. The numbers N, M, Wi and Ci are integers in the range 
    // [1..500]. Example: M=10 kg, N=6, products:
    //
    // beer – weight=3, cost=2
    // vodka – weight=8, cost=12
    // cheese – weight=4, cost=5
    // nuts – weight=1, cost=4
    // ham – weight=2, cost=3
    // whiskey – weight=8, cost=13

    class Program
    {
        //static string[] names;
        //static int[] weights;
        //static int[] costs;
        //static int[,] matrix;
        //static int[,] picks;

        private static int Knapsack(int n, int size,
            int[] weights, int[] cost, int[,] matrix, int[,] picks)
        {
            for (int i = 1; i <= n; i++)
            {
                for (int j = 0; j <= size; j++)
                {
                    if (weights[i - 1] <= j)
                    {
                        var temp = cost[i - 1] + matrix[i - 1, j - weights[i - 1]];
                        matrix[i, j] = Math.Max(matrix[i - 1, j], temp);

                        if (temp > matrix[i - 1, j])
                        {
                            picks[i, j] = 1;
                        }
                        else
                        {
                            picks[i, j] = -1;
                            matrix[i, j] = matrix[i - 1, j];
                        }
                    }
                }
            }

            return matrix[n, size];
        }

        static void PrintPicks(int n, int size, int[] weights,
            string[] names, int[,] picks)
        {
            while (n > 0)
            {
                if (picks[n, size] == 1)
                {
                    Console.WriteLine(names[n - 1]);
                    n--;
                    size -= weights[n];
                }
                else
                {
                    n--;
                }
            }

            Console.WriteLine("\n");

            return;
        }

        static void Main(string[] args)
        {
            const int n = 6;
            int knapsackSize = 10;
            string[] names = new string[n] { 
                "beer", "vodka", "cheese", "nuts", "ham", "whiskey" };
            int[] weights = new int[n] { 3, 8, 4, 1, 2, 8 };
            int[] costs = new int[n] { 2, 12, 5, 4, 3, 13 };
            int[,] matrix = new int[n + 1, knapsackSize + 1];
            int[,] picks = new int[n + 1, knapsackSize + 1];

            Console.WriteLine("Optimal solution: {0}",
                Knapsack(n, knapsackSize, weights, costs, matrix, picks));
            PrintPicks(n, knapsackSize, weights, names, picks);
        }
    }
}
