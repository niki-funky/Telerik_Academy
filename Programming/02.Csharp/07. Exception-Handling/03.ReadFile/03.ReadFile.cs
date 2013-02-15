using System;

class ReadFile
{
    // Write a program that enters file name along
    // with its full file path (e.g. C:\WINDOWS\win.ini),
    // reads its contents and prints it on the console
    // Find in MSDN how to use System.IO.File.ReadAllText(…).
    // Be sure to catch all possible exceptions and print
    // user-friendly error messages.

    static void Main()
    {
        try
        {
            Console.WriteLine("Enter fullpath of file : ");
            //string filepath = Console.ReadLine();
            string filepath = @"..\..\..\problem3.txt"; 

            Console.WriteLine(System.IO.File.ReadAllText(filepath));
        }
        catch(Exception ex)
        {
            Console.WriteLine("Oops something went wrong!" +"\n"+ ex.Message);
        }

    }
}
