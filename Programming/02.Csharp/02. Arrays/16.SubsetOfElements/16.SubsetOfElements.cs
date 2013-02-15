using System;

class SubsetOfElements
{
    //* We are given an array of integers and a number S.
    //Write a program to find if there exists a subset of
    //the elements of the array that has a sum S. Example:
    //arr={2, 1, 2, 4, 3, 5, 2, 6}, S=14 -> yes (1+2+5+6)


    static void Main()
    {
        //variables
        int[] array = new int[10];
        int s = int.Parse(Console.ReadLine());
        Random rand = new Random();
        int counter = 0;

        //expressions
        //fill the array with Random numbers
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
        for (int i = 1; i < Math.Pow(2, array.Length)-1; i++)
        {
            string subset = null;
            int sum = 0;
            int member;
            for (int j = 0; j < array.Length; j++)
            {
                member = ((i >> j) & 1) * array[j];

                if (member != 0)
                {
                    subset = subset + " " + array[j].ToString("+#;-#;0");
                }
                sum += member;
            }
            //cycle prints to console when sum of some subset is S
            if (sum == s)
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