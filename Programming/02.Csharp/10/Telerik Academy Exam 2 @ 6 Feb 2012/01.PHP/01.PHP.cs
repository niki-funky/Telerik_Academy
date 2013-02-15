using System;
using System.Linq;
using System.Text;

namespace TelerikAcademyExam2_6Feb2012
{
    class Program
    {
        static void Main(string[] args)
        {
            //variables
            string input;
            StringBuilder array = new StringBuilder();

            //StreamReader sr = new StreamReader("../../../text.txt"); //for test purposes

            bool isInOneLineComments = false;
            bool isInMultiLineComments = false;
            bool isInVariable = false;

            do
            {
                //input = sr.ReadLine();                               //for test purposes
                input = Console.ReadLine();

                for (int i = 0; i < input.Length; i++)
                {
                    //remove comments
                    if (isInOneLineComments
                        && i == 0)
                    {
                        isInOneLineComments = false;
                    }
                    if (isInMultiLineComments
                        && input[i] == '*'
                        && i != input.Length - 1)
                    {
                        if (input[i + 1] == '/')
                        {
                            isInMultiLineComments = false;
                            continue;                       //?
                        }
                    }
                    //ignore comments
                    if (isInOneLineComments)
                    {
                        continue;
                    }
                    if (isInMultiLineComments)
                    {
                        continue;
                    }
                    //get comments
                    if (input[i] == '/'
                        && i != input.Length - 1)
                    {
                        if (input[i + 1] == '/')
                        {
                            isInOneLineComments = true;
                            continue;
                        }
                    }
                    if (input[i] == '#')
                    {
                        isInOneLineComments = true;
                        continue;
                    }
                    if (input[i] == '/'
                        && i != input.Length - 1)
                    {
                        if (input[i + 1] == '*')
                        {
                            isInMultiLineComments = true;
                            continue;
                        }
                    }
                    //get variables
                    if (input[i] == '$'
                        && !isInVariable
                        && (i == 0 
                        || (input[i - 1] != '\\'
                        ||  input[i - 2] == '\\')))
                    {
                        isInVariable = true;
                        continue;
                    }
                    if (isInVariable
                        && (char.IsDigit(input[i])
                        || char.IsLetter(input[i])
                        || input[i] == '_'))
                    {
                        array.Append(input[i].ToString());
                    }
                    if (isInVariable
                        && !char.IsDigit(input[i])
                        && !char.IsLetter(input[i])
                        && input[i] != '_')
                    {
                        isInVariable = false;
                        array.Append(" ");

                        if (input[i] == '$')
                        {
                            isInVariable = true;
                        }
                    }
                }
            }
            while (input != "?>");

            //split, remove duplicates and sort array
            char[] separator = { ' ' };
            var result = array.ToString().Split(separator, StringSplitOptions.RemoveEmptyEntries);
            result = result.Distinct().ToArray();
            Array.Sort(result, StringComparer.Ordinal);

            //print number of vars
            Console.WriteLine(result.Length);

            //print all strings in the List
            foreach (var item in result)
            {
                Console.WriteLine(item);
            }
        }
    }
}