using System;

namespace ConditionalStatements
{
    class SortThreeRealNumbers
    {
        //Sort 3 real values in descending order using nested if statements.

        static void Main()
        {
            //variables
            double firstint = DoubleFromConsole();
            double secondInt = DoubleFromConsole();
            double thirdInt = DoubleFromConsole();
            double biggestInt;
            double lessInt;
            double leastInt;

            //expressions
            if (firstint < secondInt)
            {
                if (secondInt < thirdInt)
                {
                    biggestInt = thirdInt;
                    lessInt= secondInt;
                    leastInt = firstint;
                }
                else
                {
                    if (firstint > thirdInt)
                    {
                        lessInt=firstint;
                        leastInt = thirdInt;
                    }
                    else
                    {
                        lessInt=thirdInt;
                        leastInt = firstint;
                    }
                    biggestInt = secondInt;
                }
            }
            else
            {
                if (firstint < thirdInt)
                {
                    biggestInt = thirdInt;
                    lessInt=firstint;
                    leastInt = secondInt;
                }
                else
                {
                    if (secondInt > thirdInt)
                    {
                        lessInt=secondInt;
                        leastInt = thirdInt;
                    }
                    else
                    {
                        lessInt=thirdInt;
                        leastInt = secondInt;
                    }
                    biggestInt = firstint;
                }
            }
            Console.WriteLine("Numbers in descending order :" 
                +"\n"+"{0}" +"\n"+"{1}" +"\n"+"{2}", 
                biggestInt,lessInt,leastInt);
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

        //parse console input to double
        static double DoubleFromConsole()
        {
            double value;
            while (true)
            {
                Console.Write("Enter a real number : ");
                if (double.TryParse(Console.ReadLine(), out value))
                {
                    break;
                }
                RedLine("Wrong Input!");
            }
            return value;
        }
    }
}
