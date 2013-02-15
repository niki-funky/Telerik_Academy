using System;
using System.Collections.Generic;
using System.Linq;

class Combinations
{
    //Write a program that reads two numbers N 
    //and K and generates all the combinations 
    //of K distinct elements from the set [1..N]. 
    //Example: N = 5, K = 2 -> {1, 2}, {1, 3}, 
    //{1, 4}, {1, 5}, {2, 3}, {2, 4}, {2, 5}, 
    //{3, 4}, {3, 5}, {4, 5}

    static void Main()
    {
        //variables
        Console.Write("N = ");
        int n = int.Parse(Console.ReadLine());
        Console.Write("K = ");
        int k = int.Parse(Console.ReadLine());
        int[] array = new int[k];
        int index;
        List<string> combinations = new List<string>();     //list to store all variations

        //fill the array with 1-s
        for (int i = 0; i < k; i++)
        {
            array[i] = 1;
        }

        //find all variations
        while (true)
        {
            int[] current = (int[])array.Clone();           //temp array for current combination
            Array.Sort(current);                            //sort array
            string str = String.Join("", current);          
            int t = str.Distinct().Count();                 //how many disitinct digits in
                                                            //current combination
            //chaeck if combination is unique
            if (!combinations.Exists(s => s == str) && str.Distinct().Count() == str.Length)
            {
                combinations.Add(str);

                #region print current variation
                Console.Write("{ ");
                for (int i = 0; i < k; i++)
                {
                    if (i != k - 1)
                    {
                        Console.Write(array[i] + ", ");
                    }
                    else
                    {
                        Console.Write(array[i]);
                    }
                }
                Console.WriteLine(" }");
                #endregion
            }

            index = k - 1;
            array[index] = array[index] + 1;
                        
            while (array[index] > n)
            {
                array[index] = 1;
                index--;

                if (index < 0)
                {
                    return;
                }
                array[index] = array[index] + 1;
            }
        }
    }
}
