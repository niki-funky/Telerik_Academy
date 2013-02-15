using System;
using System.Linq;

class Polynomials
{
    // 11.Write a method that adds two polynomials. 
    // Represent them as arrays of their coefficients
    // as in the example below:
    // x2 + 5 = 1x2 + 0x + 5 -> 5 0 1

    // 12.Extend the program to support also 
    // subtraction and multiplication of polynomials.


    static void PrintResult(decimal[] polynomial, string operation)
    {
        Console.Write("Result of {0} polynomials is : ", operation);
        for (int i = 0; i < polynomial.Length; i++)
        {
            Console.Write(polynomial[i] + " ");
        }
        Console.WriteLine();
    }

    static decimal[] Addition(decimal[] first, decimal[] second)
    {
        //new array with length equal to the bigger polynomial 
        decimal[] sum = new decimal[Math.Max(first.Length, second.Length)];
        int min = Math.Min(first.Length, second.Length);
        //sum common members
        for (int i = 0; i < min; i++)
        {
            sum[i] = first[i] + second[i];
        }
        //add members of the bigger polynomial 
        for (int i = min; i < sum.Length; i++)
        {
            if (first.Length > second.Length)
            {
                sum[i] = first[i];
            }
            if (first.Length < second.Length)
            {
                sum[i] = second[i];
            }
        }
        return sum;
    }

    static decimal[] Subtraction(decimal[] first, decimal[] second)
    {
        //new array with length equal to the bigger polynomial 
        decimal[] sum = new decimal[Math.Max(first.Length, second.Length)];
        int min = Math.Min(first.Length, second.Length);
        //subtract common members
        for (int i = 0; i < min; i++)
        {
            sum[i] = first[i] - second[i];
        }
        //add members of the bigger polynomial 
        for (int i = min; i < sum.Length; i++)
        {
            if (first.Length > second.Length)
            {
                sum[i] = first[i];
            }
            if (first.Length < second.Length)
            {
                sum[i] = second[i];
            }
        }
        return sum;
    }

    static decimal[] Multiplication(decimal[] first, decimal[] second)
    {
        decimal[] sum = new decimal[first.Length + second.Length - 1];
        for (int i = 0; i < first.Length; i++)
        {
            for (int j = 0; j < second.Length; j++)
            {
                sum[i + j] += first[i] * second[j];
            }
        }
        return sum;
    }

    static void Main()
    {
        //variables
        Console.WriteLine("Enter highest power of the first polynomial: ");
        int exponent1 = int.Parse(Console.ReadLine());
        Console.WriteLine("Enter highest power of the second polynomial: ");
        int exponent2 = int.Parse(Console.ReadLine());

        decimal[] first = new decimal[exponent1];
        decimal[] second = new decimal[exponent2];

        #region input coefficients
        for (int i = 0; i < first.Length; i++)
        {
            Console.WriteLine("Enter coefficient for first polynomial X^{0} : ", i);
            first[i] = decimal.Parse(Console.ReadLine());
        }
        Array.Reverse(first);

        for (int i = 0; i < second.Length; i++)
        {
            Console.WriteLine("Enter coefficient of second polynomial X^{0} : ", i);
            second[i] = decimal.Parse(Console.ReadLine());
        }
        Array.Reverse(second);
        #endregion

        //print result
        PrintResult(Addition(first, second), "adding");
        PrintResult(Subtraction(first, second), "subtraction");
        PrintResult(Multiplication(first, second), "multiplication");
    }
}