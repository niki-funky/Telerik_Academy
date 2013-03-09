using System;
using System.Linq;

namespace StringExtension
{
    //07. Write extension method to the String class 
    // that capitalizes the first letter of each word.
    // Use the method TextInfo.ToTitleCase().

    class Program
    {
        static void Main(string[] args)
        {
            //test
            string str = "Софтуерната академия на Телерик предоставя практическо обучение по програмиране за млади хора с малко или никакъв опит в разработката на софтуер, мотивирани да станат умели .NET специалисти.";
            Console.WriteLine(str.Capitalize());
        }
    }
}
