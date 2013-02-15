using System;
using System.Text;

namespace PrimitiveDataTypes
{
    class ASCII
    {
        //Find online more information about ASCII 
        //(American Standard Code for Information Interchange) 
        //and write a program that prints the entire ASCII table of characters on the console.

        static void Main()
        {
            //char symbol;
            Console.OutputEncoding = Encoding.ASCII;

            for (int i = 0; i < 255; i++)
            {
                Console.WriteLine((char)(i));
            }
        }
    }
}
