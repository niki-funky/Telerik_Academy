using System;

class SortingArrayOfStrings
{
    // Write a program that sorts an array of strings 
    // using the quick sort algorithm (find it in Wikipedia).

    static void Main()
    {
        //variables
        string[] array = new string[7];

        //fill the Array with Random strings
        for (int i = 0; i < array.Length; i++)
        {
            array[i] = RandomString();
        }

        #region print original array
        Console.Write("{");
        for (int i = 0; i < array.Length; i++)
        {
            Console.Write(array[i]);
            if (i != array.Length - 1)
            {
                Console.Write(',' + " ");
            }
        }
        Console.Write("} -> { ");
        #endregion

        //sort the array using Quick Sort algorithm
        quickSort(array, 0, array.Length - 1);

        #region print sorted array
        for (int i = 0; i < array.Length; i++)
        {
            Console.Write(array[i]);
            if (i != array.Length - 1)
            {
                Console.Write(',' + " ");
            }
        }
        Console.WriteLine(" }");
        #endregion
    }

    #region Generate Random strings
    private static Random random = new Random();
    //Generate Random string
    private static string RandomString()
    {
        char letter = (char)random.Next(0x41, 0x5A);
        return letter.ToString();
    }
    #endregion

    #region Quick Sort algotithm
    //method that swaps 2 elements in array
    private static void quickSwap(string[] Array, int Left, int Right)
    {
        if (Left == Right)
        {
            return;
        }
        string Temp = Array[Right];
        Array[Right] = Array[Left];
        Array[Left] = Temp;
    }

    public static String[] quickSort(string[] Array, int Left, int Right)
    {
        int lHold = Left;
        int rHold = Right;
        Random ObjRandom = new Random();
        int pivot = ObjRandom.Next(Left, Right);
        quickSwap(Array, pivot, Left);
        pivot = Left;
        Left++;

        while (Right >= Left)
        {
            int leftValue = Array[Left].CompareTo(Array[pivot]);
            int rightValue = Array[Right].CompareTo(Array[pivot]);

            if ((leftValue >= 0) && (rightValue < 0))
            {
                quickSwap(Array, Left, Right);
            }
            else
            {
                if (leftValue >= 0)
                {
                    Right--;
                }
                else
                {
                    if (rightValue < 0)
                    {
                        Left++;
                    }
                    else
                    {
                        Right--;
                        Left++;
                    }
                }
            }
        }
        quickSwap(Array, pivot, Right);
        pivot = Right;
        if (pivot > lHold)
        {
            quickSort(Array, lHold, pivot);
        }
        if (rHold > pivot + 1)
        {
            quickSort(Array, pivot + 1, rHold);
        }
        return Array;
    }
    #endregion
}