using System;
using System.Numerics;


class TribonacciSequence
{
    //Write a computer program that finds the Nth element 
    //of the Tribonacci sequence, if you are given the first 
    //three elements of the sequence and the number N. 
    //Mathematically said: with given T1, T2 and T3 – you must find Tn.

    static void Main()
    {
        //variables
        BigInteger t1 = BigInteger.Parse(Console.ReadLine());
        BigInteger t2 = BigInteger.Parse(Console.ReadLine());
        BigInteger t3 = BigInteger.Parse(Console.ReadLine());
        ushort number = ushort.Parse(Console.ReadLine());
        BigInteger nMember = 0;

        //expressions
        if (number < 4)
        {
            if (number == 1)
            {
                nMember = t1;
            }
            else if (number == 2)
            {
                nMember = t2;
            }
            else
            {
                nMember = t3;
            }
        }

        for (int i = 4; i <= number; i++)
        {
            nMember = t1 + t2 + t3;
            t1 = t2;
            t2 = t3;
            t3 = nMember;
        }
        Console.WriteLine(nMember);
    }
}
