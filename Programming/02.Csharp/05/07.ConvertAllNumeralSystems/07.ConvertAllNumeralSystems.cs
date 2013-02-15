using System;

class ConvertAllNumeralSystems
{
    // Write a program to convert from any numeral
    // system of given base s to any other numeral 
    // system of base d (2 ≤ s, d ≤  16).

    static void Main()
    {
        //variables
        long decimalNumber = 0;
        string result = "";
        Console.WriteLine("Enter base s to convert from: ");
        byte s = byte.Parse(Console.ReadLine());
        Console.WriteLine("Enter number from base s: ");
        string number = Console.ReadLine();
        Console.WriteLine("Enter base d to convert to it: ");
        byte d = byte.Parse(Console.ReadLine());

        //Convert to decimal number
        decimalNumber = BaseStoDecimal(number, s);

        //Convert to d base number
        result = DecimalToBaseD(decimalNumber, d);

        //Reverse the string
        char[] array = result.ToCharArray();
        Array.Reverse(array);

        //print result
        Console.Write("-> ");
        for (int i = 0; i < array.Length; i++)
        {
            Console.Write(array[i]);
        }
        Console.WriteLine();
    }

    //convert from base s to decimal
    public static long BaseStoDecimal(string d,int baseS)
    {
        long dec = 0;
        //for (int i = 0; i < d.Length; i++)
        //{
            dec += Convert.ToInt64(d, baseS);
                       
        //}
        return dec;
    }

    //convert from decimal to base d
    public static string DecimalToBaseD(long dec, int baseD)
    {
        string result = String.Empty;
        while (dec > 0)
        {
            switch (dec % baseD)
            {
                case 0: result += "0"; break;
                case 1: result += "1"; break;
                case 2: result += "2"; break;
                case 3: result += "3"; break;
                case 4: result += "4"; break;
                case 5: result += "5"; break;
                case 6: result += "6"; break;
                case 7: result += "7"; break;
                case 8: result += "8"; break;
                case 9: result += "9"; break;
                case 10: result += "A"; break;
                case 11: result += "B"; break;
                case 12: result += "C"; break;
                case 13: result += "D"; break;
                case 14: result += "E"; break;
                case 15: result += "F"; break;
            }
            dec = dec / baseD;
        }

        return result;
    }
}