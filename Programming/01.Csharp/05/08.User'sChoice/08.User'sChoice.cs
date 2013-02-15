using System;

namespace ConditionalStatements
{
    class UserChoice
    {
        //Write a program that, depending on the user's choice inputs int, double or string variable.
        //If the variable is integer or double, increases it with 1. 
        //If the variable is string, appends "*" at its end. 
        //The program must show the value of that variable as a console output. Use switch statement.

        static void Main()
        {
            //variables
            int integerInput;
            double doubleInput;
            string stringinput;
            string typeOfVariable = "string";

            //expressions
            Console.Write("Enter int, double or string variable : ");
            stringinput = Console.ReadLine();

            if (int.TryParse(stringinput, out integerInput))
            {
                typeOfVariable = "integer";
            }
            if (double.TryParse(stringinput, out doubleInput))
            {
                typeOfVariable = "double";
            }

            switch (typeOfVariable)
            {
                case "integer":
                    Console.WriteLine(integerInput+1);
                    break;
                case "double":
                    Console.WriteLine(doubleInput+1);
                    break;
                case "string":
                    Console.WriteLine(stringinput + "*");
                    break;
            }
        }
    }
}
