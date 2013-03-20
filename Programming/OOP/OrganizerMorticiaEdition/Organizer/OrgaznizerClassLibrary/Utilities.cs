using OrganizerClassLibrary.Enums;
using OrganizerClassLibrary.UserInterfaceClasses;
using System;
using System.Collections.Generic;
using System.Linq;

namespace OrganizerClassLibrary
{
    public static class Utilities
    {
        public static T EnumParser<T>(string input)
        {
            return (T)Enum.Parse(typeof(T), input, true);
        }

        public static List<T> EnumToList<T>()
            where T : struct
        {
            return Enum.GetValues(typeof(T)).Cast<T>().ToList();
        }

        //draw text on console in color
        public static string TextColorChanger(string value, Color color, Color backColor = Color.White)
        {
            ConsoleColor backColour = (ConsoleColor)Enum.Parse(typeof(ConsoleColor), color.ToString());
            Console.ForegroundColor = backColour;
            return (value);
        }

        //draw text on console in color
        public static void PrintColorMessage(string value, Color color, Color backColor = Color.White)
        {
            ConsoleColor backColour = (ConsoleColor)Enum.Parse(typeof(ConsoleColor), color.ToString());
            Console.ForegroundColor = backColour;
            Console.WriteLine(value);

            ResetConsoleColor();
        }

        //make console red if wrong input
        public static string RedMessage(string value)
        {
            Console.BackgroundColor = ConsoleColor.Red;
            Console.ForegroundColor = ConsoleColor.Black;
            Console.Write(value);

            ResetConsoleColor();
            return "";
        }

        public static void ResetConsoleColor()
        {
            Console.ResetColor();
        }

        public static void GoToMainMenu(OrganizerCore core)
        {
            Console.WriteLine();
            UserInterface.MainMenu(core);
        }
    } 
}
