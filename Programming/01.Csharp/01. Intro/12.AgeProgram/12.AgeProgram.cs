using System;

    class AgeProgram
    {
        //* Write a program to read your age from the console 
        //and print how old you will be after 10 years.

        static void Main()
        {
            int birthYear;
            while(true)
            {
                Console.WriteLine("Please enter your age: ");

                if ( int.TryParse(Console.ReadLine(), out birthYear )
                    && birthYear>0 
                    && birthYear.ToString().Length<4)
                {
                    break;
                }
                ColoredLine("Wrong input!");
            }
            Console.WriteLine("In 10 years you will be: {0}", birthYear+10 );
        }
        static void ColoredLine(string value)
        {
            Console.BackgroundColor = ConsoleColor.Red;
            Console.ForegroundColor = ConsoleColor.Black;
            Console.WriteLine(value);

            // Reset the color
            Console.ResetColor();
        }
    }
