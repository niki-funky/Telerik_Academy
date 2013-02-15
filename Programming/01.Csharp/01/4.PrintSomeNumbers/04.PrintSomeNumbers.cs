using System;

    class PrintSomeNumbers
    {
        //Write a program to print the numbers 1, 101 and 1001.

        static void Main()
        {
            Console.WriteLine("{0,5}" 
                + "\r\n" 
                + "{1,5}" 
                +"\r\n"  
                + "{2,5}",1, 101, 1001);
        }
    }
