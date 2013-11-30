
namespace SumAndAverageOfSequence
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    // 01. Write a program that reads from the console a sequence 
    // of positive integer numbers. The sequence ends when empty 
    // line is entered. Calculate and print the sum and average of 
    // the elements of the sequence. Keep the sequence in List<int>.

    public class SumAndAverageOfSequence
    {
        private static List<int> sequence;

        private static void ReadUserInput()
        {
            sequence = new List<int>();
            var inputLine = Console.ReadLine();

            while (!string.IsNullOrEmpty(inputLine))
            {
                int number = int.Parse(inputLine);
                if (number > 0)
                {
                    sequence.Add(number);
                }
                inputLine = Console.ReadLine();
            }
        }

        private static int Sum()
        {
            int result = sequence.Take(sequence.Count).Sum();

            return result;
        }

        private static double Average()
        {
            double result = sequence.Average();

            return result;
        }

        public static void Main()
        {
            Console.WriteLine("Enter some positive numbers: ");
            ReadUserInput();

            var sum = Sum();
            Console.WriteLine("Sum of all numbers is: " + sum);

            var average = Average();
            Console.WriteLine("Average of all numbers is: " + average);
        }
    }
}
