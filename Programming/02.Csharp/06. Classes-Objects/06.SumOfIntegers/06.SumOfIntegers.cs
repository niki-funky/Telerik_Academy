using System;
using System.Linq;

class SumOfIntegers
{
    // You are given a sequence of positive integer values 
    // written into a string, separated by spaces. Write a 
    // function that reads these values from given string 
    // and calculates their sum. Example:
    // string = "43 68 9 23 318" -> result = 461

    static void Main()
    {
        //variables
        Console.WriteLine("Enter some Integers separated by space -> ");
        string[] numbers = Console.ReadLine().Split(' ');
        int sum = 0;

        foreach (var item in numbers)
        {
            if (item != "")
            {
                sum = sum + int.Parse(item);
            }
        }
        Console.WriteLine("result = {0}.", sum);
    }
}
