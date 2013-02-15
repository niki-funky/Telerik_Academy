using System;
using System.Collections.Generic;

class RemoveElementsFromArray
{
    //* Write a program that reads an array of integers 
    //and removes from it a minimal number of elements 
    //in such way that the remaining array is sorted in
    //increasing order. Print the remaining sorted array.
    //Example: {6, 1, 4, 3, 0, 3, 6, 4, 5} -> {1, 3, 3, 4, 5}

    static void Main()
    {
        //variables
        int[] array = new int[10];
        List<int> subsets = new List<int>();
        Random rand = new Random();

        //fill the array with numbers
        for (int i = 0; i < array.Length; i++)
        {
            array[i] = rand.Next(-9, 9);
        }

        #region print array
        Console.Write("{");
        for (int i = 0; i < array.Length; i++)
        {
            Console.Write(array[i]);
            if (i != array.Length - 1)
            {
                Console.Write(',' + " ");
            }
        }
        Console.WriteLine("}");
        #endregion

        //2^array.Length combinations
        for (int i = 1; i < Math.Pow(2, array.Length) - 1; i++)
        {
            int member;
            List<int> members = new List<int>();
            int value = int.MinValue;

            for (int j = 0; j < array.Length; j++)
            {
                member = ((i >> j) & 1) * array[j];

                if (member != 0 && array[j] >= value)
                {
                    value = array[j];
                    members.Add(array[j]);
                }
            }
            //check if current List is bigger than default List
            if (members.Count > subsets.Count)
            {
                subsets.Clear();
                subsets.AddRange(members);
            }
        }

        #region print sorted array
        Console.Write(" => { ");
        for (int i = 0; i < subsets.Count; i++)
        {
            Console.Write(subsets[i].ToString("#;-#;0"));
            if (i != subsets.Count - 1)
            {
                Console.Write(',' + " ");
            }
        }
        Console.WriteLine(" }");
        #endregion
    }
}