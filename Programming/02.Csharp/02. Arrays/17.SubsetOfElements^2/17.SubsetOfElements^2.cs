using System;

class SubsetOfElements2
{
    //* Write a program that reads three integer numbers N, K and S
    //and an array of N elements from the console. Find in the array
    //a subset of K elements that have sum S or indicate about its absence.

    static void Main()
    {
        //variables
        int n = int.Parse(Console.ReadLine());
        int k = int.Parse(Console.ReadLine());
        int s = int.Parse(Console.ReadLine());
        int[] array = new int[n];
        Random rand = new Random();
        int counter = 0;
 
        //fill the array with numbers
        for (int i = 0; i < n; i++)
        {
            //array[i] = int.Parse(Console.ReadLine());
            array[i] = rand.Next(-9, 9);
        }

        #region print array
        Console.Write("{");
        for (int i = 0; i < n; i++)
        {
            Console.Write(array[i]);
            if (i != n - 1)
            {
                Console.Write(',' + " ");
            }
        }
        Console.WriteLine("}");
        #endregion

        //2^array.Length combinations
        //cycle finds all subsets
        for (int i = 1; i < Math.Pow(2, n) - 1; i++)
        {
            string subset = null;
            int sum = 0;
            int member;
            int elements = 0;

            for (int j = 0; j < n; j++)
            {
                member = ((i >> j) & 1) * array[j];

                if (member != 0)
                {
                    subset = subset + " " + array[j].ToString("+#;-#;0");
                    elements++;
                }
                sum += member;
            }
            //cycle prints to console when sum of some subset is S
            //cycle can be stopped on first result
            if (sum == s && elements == k)
            {
                Console.WriteLine(" => ({0}) = {1}", subset, s);
                counter++;
            }
        }

        //check if there is no sum S 
        if (counter == 0)
        {
            Console.WriteLine(" => no");
        }
    }
}