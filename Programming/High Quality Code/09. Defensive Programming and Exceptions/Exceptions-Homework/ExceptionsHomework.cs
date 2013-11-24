//-----------------------------------------------------------------------
// <copyright file="ExceptionsHomework.cs" company="TelerikAcademy">
//     All rights reserved © Telerik Academy 2012-2013
// </copyright>
//----------------------------------------------------------------------
using System;
using System.Collections.Generic;
using System.Text;

public class ExceptionsHomework
{
    public static T[] Subsequence<T>(T[] array, int startIndex, int count)
    {
        if (array == null)
        {
            throw new ArgumentNullException("Array cannot be null.");
        }

        if (startIndex < 0 || startIndex > array.Length)
        {
            throw new ArgumentOutOfRangeException("Start index must be greater than zero and less than arrays' length.");
        }

        if (count < 0)
        {
            throw new ArgumentOutOfRangeException("Count cannot be less than zero.");
        }

        if (startIndex + count > array.Length)
        {
            throw new ArgumentOutOfRangeException("Count plus start index must be less than arrays' length.");
        }

        List<T> result = new List<T>();
        for (int i = startIndex; i < startIndex + count; i++)
        {
            result.Add(array[i]);
        }

        return result.ToArray();
    }

    public static string ExtractEnding(string value, int count)
    {
        if (value == null)
        {
            throw new ArgumentNullException("Value must not be null.");
        }

        if (count < 0)
        {
            throw new ArgumentOutOfRangeException("Count must be positive.");
        }

        if (count > value.Length)
        {
            throw new ArgumentOutOfRangeException("Count must be less than value length!");
        }

        StringBuilder result = new StringBuilder();
        for (int i = value.Length - count; i < value.Length; i++)
        {
            result.Append(value[i]);
        }

        return result.ToString();
    }

    public static bool IsPrime(int number)
    {
        if (number < 2)
        {
            throw new ArgumentOutOfRangeException("Number must be greater than or equal to 2.");
        }

        for (int divisor = 2; divisor <= Math.Sqrt(number); divisor++)
        {
            if (number % divisor == 0)
            {
                return false;
            }
        }

        return true;
    }

    internal static void Main()
    {
        try
        {
            var substr = Subsequence("Hello!".ToCharArray(), 2, 3);
            Console.WriteLine(substr);

            var subarr = Subsequence(new int[] { -1, 3, 2, 1 }, 0, 2);
            Console.WriteLine(String.Join(" ", subarr));

            var allarr = Subsequence(new int[] { -1, 3, 2, 1 }, 0, 4);
            Console.WriteLine(String.Join(" ", allarr));

            var emptyarr = Subsequence(new int[] { -1, 3, 2, 1 }, 0, 0);
            Console.WriteLine(String.Join(" ", emptyarr));

            Console.WriteLine(ExtractEnding("I love C#", 2));
            Console.WriteLine(ExtractEnding("Nakov", 4));
            Console.WriteLine(ExtractEnding("beer", 4));

            // this line throws Exception
            Console.WriteLine(ExtractEnding("Hi", 100));

            bool isPrime = IsPrime(23);
            if (isPrime)
            {
                Console.WriteLine("23 is prime.");
            }
            else
            {
                Console.WriteLine("23 is not prime.");
            }

            isPrime = IsPrime(33);
            if (isPrime)
            {
                Console.WriteLine("33 is prime.");
            }
            else
            {
                Console.WriteLine("33 is not prime.");
            }

            List<Exam> peterExams = new List<Exam>()
            {
                new SimpleMathExam(2),
                new CSharpExam(55),
                new CSharpExam(100),
                new SimpleMathExam(1),
                new CSharpExam(0),
            };
            Student peter = new Student("Peter", "Petrov", peterExams);
            double peterAverageResult = peter.CalcAverageExamResultInPercents();
            Console.WriteLine("Average results = {0:p0}", peterAverageResult);
        }
        catch (ArgumentOutOfRangeException ex)
        {
            // var lineNumber = new StackTrace(ex, true).GetFrame(0).GetFileLineNumber();
            Console.WriteLine(ex.ParamName);
        }
    }
}
