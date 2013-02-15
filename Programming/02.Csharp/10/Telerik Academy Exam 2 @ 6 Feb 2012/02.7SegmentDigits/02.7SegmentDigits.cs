using System;
using System.Collections.Generic;
using System.Linq;

class _7SegmentDigits
{
    static readonly byte[] digits = new byte[10]
        {
            Convert.ToByte("1111110", 2), // 0
            Convert.ToByte("0110000", 2), // 1
            Convert.ToByte("1101101", 2), // 2
            Convert.ToByte("1111001", 2), // 3
            Convert.ToByte("0110011", 2), // 4
            Convert.ToByte("1011011", 2), // 5
            Convert.ToByte("1011111", 2), // 6
            Convert.ToByte("1110000", 2), // 7
            Convert.ToByte("1111111", 2), // 8
            Convert.ToByte("1111011", 2), // 9
        };

    static List<string> combinations = new List<string>();

    static void Main()
    {
        //variables
        int n = int.Parse(Console.ReadLine());
        byte[] listOfDigits = new byte[n];
        List<List<char>> arr = new List<List<char>>(n);
        for (int i = 0; i < n; i++)
        {
            listOfDigits[i] = Convert.ToByte(Console.ReadLine(), 2);
        }

        //find all possible states for each digit
        for (int i = 0; i < listOfDigits.Length; i++)
        {
            arr.Add(FindDigit(listOfDigits[i]));
        }

        //find all combinations
        FindCombinations("", arr, 0);

        //print number of combinations
        Console.WriteLine(combinations.Count);

        //print all combinations
        foreach (var item in combinations)
        {
            Console.WriteLine(item);
        }
    }

    //find all possible states for each digit
    static List<char> FindDigit(byte digit)
    {
        List<char> ch = new List<char>();
        bool nextWord = false;

        for (int i = 0; i < 10; i++)
        {
            for (int l = 6; l >= 0; l--)
            {
                if (((digit >> 6 - l) & 1) == 1
                    && ((digits[i] >> 6 - l) & 1) == 0)
                {
                    nextWord = false;
                    break;
                }
                nextWord = true;
            }
            if (nextWord)
            {
                ch.Add((char)('0' + i));
            }
        }
        return ch;
    }

    //find all combinations
    static void FindCombinations(string str, List<List<char>> multiArray, int position)
    {
        if (position == multiArray.Count)
        {
            combinations.Add(str);
        }
        else
        {
            foreach (object item in multiArray[position])
            {
                FindCombinations(str + item.ToString(), multiArray, position + 1);
            }
        }
    }
}
