using System;

namespace PrimitiveDataTypes
{
    class ExchangeValues
    {
        //Declare  two integer variables and assign them with 5 and 10 and after that exchange their values.

        static void Main()
        {
            int first = 5;
            int second = 10;
            int third;
            third = first;
            first = second;
            second = third;
            Console.WriteLine("{0} , {1}",first,second);
        }
    }
}
