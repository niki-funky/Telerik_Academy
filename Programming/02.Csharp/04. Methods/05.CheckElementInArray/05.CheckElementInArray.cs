using System;
using System.Linq;

namespace Methods
{
    public class CheckElementInArray
    {
        // Write a method that checks if the element at given 
        // position in given array of integers is bigger than 
        // its two neighbors (when such exist).

        static void Main()
        {
            //variables
            Console.WriteLine("write the index of a number in array:");
            int number = int.Parse(Console.ReadLine());
            int[] array = new int[10];
            Random rand = new Random();

            //fill the array with Random numbers
            for (int i = 0; i < array.Length; i++)
            {
                array[i] = rand.Next(9);
            }

            #region print array
            Console.Write("{");
            Console.Write(String.Join(", ", array));
            Console.WriteLine("} -> ");
            #endregion

            //print result
            if (CompareNumbers(array, number))
            {
                Console.WriteLine("Element at index {0} is bigger than its neighbours", number);
            }
            else
            {
                Console.WriteLine("Element at index {0} is NOT bigger than its neighbours", number);
            }
        }

        public static bool CompareNumbers(int[] array, int index)
        {
            bool biggest = false;
            if (index != 0 && index != array.Length - 1)
            {
                if (array[index] > array[index - 1] && array[index] > array[index + 1])
                {
                    biggest = true;
                }
            }

            return biggest;
        }
    }
}