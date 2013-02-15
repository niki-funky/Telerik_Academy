using System;

namespace ConditionalStatements
{
    class ConvertNumberToText
    {
        //* Write a program that converts a number in the range [0...999]
        //to a text corresponding to its English pronunciation. Examples:
        //0 -> "Zero"
        //273 -> "Two hundred seventy three"
        //400 -> "Four hundred"
        //501 -> "Five hundred and one"
        //711 -> "Seven hundred and eleven"

        static void Main()
        {
            //variables
            int number;
            while (true)
            {
                Console.Write("Enter a number : ");
                if (int.TryParse(Console.ReadLine(), out number) && number >= 0 && number < 1000)
                {
                    break;
                }
                RedLine("Wrong Input!");
            }
            int firstDigit;
            int secondDigit;
            int lastDigit;
            string numberToText = null;

            //expressions
            #region number > 99

            if (number > 99)
            {
                firstDigit = number / 100;
                secondDigit = number / 10 - ((number / 100) * 10);
                lastDigit = number - ((number / 10) * 10);
                if (secondDigit == 0)
                {
                    if (lastDigit == 0)
                    {
                        numberToText = oneToNine(firstDigit) + " hundred " + tenToNineteen(number % 100);
                    }
                    else
                    {
                        numberToText = oneToNine(firstDigit) + " hundred and " + oneToNine(lastDigit);
                    }
                }

                else if (secondDigit == 1)
                {
                    numberToText = oneToNine(firstDigit) + " hundred and " + tenToNineteen(number % 100);
                }
                else
                {
                    numberToText = oneToNine(firstDigit) + " hundred and " + tenToNinety(secondDigit * 10) + " " + oneToNine(lastDigit);
                }
            }
            #endregion

            #region number < 100

            if (number < 100)
            {
                if (number < 10)
                {
                    numberToText = oneToNine(number);
                }
                else if (number < 20 && number > 10)
                {
                    numberToText = tenToNineteen(number);
                }
                else if (number % 10 == 0)
                {
                    numberToText = tenToNinety(number);
                }
                else
                {
                    firstDigit = number / 10;
                    secondDigit = number - ((number / 10) * 10);
                    numberToText = tenToNinety(firstDigit * 10) + " " + oneToNine(secondDigit);
                }
            }
            #endregion
            Console.WriteLine(numberToText);
        }
        //numbers from 1...9
        static string oneToNine(int digit)
        {
            string text = null;
            switch (digit)
            {
                case 1:
                    text = "one";
                    break;
                case 2:
                    text = "two";
                    break;
                case 3:
                    text = "three";
                    break;
                case 4:
                    text = "four";
                    break;
                case 5:
                    text = "five";
                    break;
                case 6:
                    text = "six";
                    break;
                case 7:
                    text = "seven";
                    break;
                case 8:
                    text = "eight";
                    break;
                case 9:
                    text = "nine";
                    break;
            }
            return text;
        }

        //numbers from 11...19
        static string tenToNineteen(int elevens)
        {
            string text = null;
            switch (elevens)
            {
                case 10:
                    text = "ten";
                    break;
                case 11:
                    text = "eleven";
                    break;
                case 12:
                    text = "twelve";
                    break;
                case 13:
                    text = "thirteen";
                    break;
                case 14:
                    text = "fourteen";
                    break;
                case 15:
                    text = "fifteen";
                    break;
                case 16:
                    text = "sixteen";
                    break;
                case 17:
                    text = "seventeen";
                    break;
                case 18:
                    text = "eighteen";
                    break;
                case 19:
                    text = "nineteen";
                    break;
            }
            return text;
        }

        //numbers from 10...90
        static string tenToNinety(int tens)
        {
            string text = null;
            switch (tens)
            {
                case 10:
                    text = "ten";
                    break;
                case 20:
                    text = "twenty";
                    break;
                case 30:
                    text = "thirty";
                    break;
                case 40:
                    text = "forty";
                    break;
                case 50:
                    text = "fifty";
                    break;
                case 60:
                    text = "sixty";
                    break;
                case 70:
                    text = "seventy";
                    break;
                case 80:
                    text = "eighty";
                    break;
                case 90:
                    text = "ninety";
                    break;
            }
            return text;
        }

        //make console red if wrong input
        static void RedLine(string value)
        {
            Console.BackgroundColor = ConsoleColor.Red;
            Console.ForegroundColor = ConsoleColor.Black;
            Console.WriteLine(value);

            // Reset the color
            Console.ResetColor();
        }
    }
}
