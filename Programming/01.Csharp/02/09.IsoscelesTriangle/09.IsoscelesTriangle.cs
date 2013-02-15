using System;
using System.Text;

namespace PrimitiveDataTypes
{
    class IsoscelesTriangle
    {
        //Write a program that prints an isosceles triangle 
        //of 9 copyright symbols ©. Use Windows Character Map to 
        //find the Unicode code of the © symbol. Note: the © symbol may be displayed incorrectly.

        static void Main()
        {
            char copyright = '\u00a9';
            //char copyright = Convert.ToChar(169);
            int column = 3;

            Console.OutputEncoding = Encoding.UTF8;

            for (int i = 0; i < 3; i++)
            {
                Console.SetCursorPosition(column, i);

                for (int symbol = 1; symbol < i*2 + 2; symbol ++)
                { 
                    Console.Write(copyright);
                }

                column--;
            }
            Console.WriteLine();
        }
    }
}