using System;

namespace PrimitiveDataTypes
{
    class ValueOf254InHex
    {
        //Declare an integer variable and assign it with the value 254
        //in hexadecimal format. Use Windows Calculator to find its hexadecimal representation.

        static void Main()
        {
            int someInt = 254;
            string valueOf254InHex = someInt.ToString("X");
            Console.WriteLine(valueOf254InHex);
        }
    }
}
