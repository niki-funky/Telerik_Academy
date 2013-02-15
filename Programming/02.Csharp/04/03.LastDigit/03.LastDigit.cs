using System;
using System.Linq;

class LastDigit
{
    // Write a method that returns the last digit of 
    // given integer as an English word. Examples: 
    // 512 -> "two", 1024 -> "four", 12309 -> "nine".

    static void Main()
    {
        //variables
        int number = int.Parse(Console.ReadLine());

        //print last digit
        Console.WriteLine("Last digit is {0}", LastDigits(number));
    }

    //get last digit
    public static string LastDigits(int integer)
    {
        string lastDigit = null;
        int i = Math.Abs(integer) % 10;
        switch (i)
        {
            case 0:
                lastDigit = "zero";
                break;
            case 1:
                lastDigit = "one";
                break;
            case 2:
                lastDigit = "two";
                break;
            case 3:
                lastDigit = "three";
                break;
            case 4:
                lastDigit = "four";
                break;
            case 5:
                lastDigit = "five";
                break;
            case 6:
                lastDigit = "six";
                break;
            case 7:
                lastDigit = "seven";
                break;
            case 8:
                lastDigit = "eight";
                break;
            case 9:
                lastDigit = "nine";
                break;
        }
        return lastDigit;
    }
}