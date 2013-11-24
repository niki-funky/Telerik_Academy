using OrganizerClassLibrary.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace OrganizerClassLibrary.UserInterfaceClasses
{
    public static class UIMessages
    {
        public static void PrintEnumElements<T>(List<T> enumeration)
        {
            StringBuilder buffer = new StringBuilder();
            int position = 1;
            if (enumeration[0].Equals(Color.Black))
            {
                foreach (var item in enumeration)
                {
                    Type type = typeof(ConsoleColor);
                    Console.BackgroundColor = (ConsoleColor)Enum.Parse(type, item.ToString());
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.WriteLine("{0}. {1}", position, item.ToString());
                    position++;
                    Console.ResetColor();
                }
            }
            else
            {
                foreach (var item in enumeration)
                {
                    Console.WriteLine("{0}. {1}", position, item.ToString());
                    position++;
                }
            }
        }

        public static void ContactMenuMessage()
        {
            Console.WriteLine();
            Utilities.PrintColorMessage("0. Back to previous menu.", Color.White);
            Utilities.PrintColorMessage("1. Create corporative.", Color.Cyan);
            Utilities.PrintColorMessage("2. Create person.", Color.Cyan);
            Console.WriteLine();
        }

        public static void PersonMenuMessage()
        {
            Console.WriteLine();
            Utilities.PrintColorMessage("0. Back to previous menu.", Color.Cyan);
            Utilities.PrintColorMessage("1. Create Business contact.", Color.Cyan);
            Utilities.PrintColorMessage("2. Create Family contact.", Color.Cyan);
            Utilities.PrintColorMessage("3. Create Friend contact.", Color.Cyan);
            Console.WriteLine();
        }

        public static void EventMenuMessage()
        {
            Console.WriteLine();
            Utilities.PrintColorMessage("0. Back to previous menu.", Color.White);
            Utilities.PrintColorMessage("1. Create category.", Color.Green);
            Utilities.PrintColorMessage("2. Create note.", Color.Green);
            Utilities.PrintColorMessage("3. Create project.", Color.Green);
            Utilities.PrintColorMessage("4. Create task.", Color.Green);
            Utilities.PrintColorMessage("5. Create task with reminder.", Color.Green);
            Console.WriteLine();
        }

        #region print properties
        public static void MainMenuMessage()
        {
            Console.WriteLine();
            Utilities.PrintColorMessage("1. Create event.", Color.Green);
            Utilities.PrintColorMessage("2. Create contact.", Color.Cyan);
            Utilities.PrintColorMessage("3. Create email", Color.Yellow);
            Utilities.PrintColorMessage("10. Exit", Color.White);
            Console.WriteLine();
        }

        public static void PrintBulstatMessage()
        {
            Console.Write("Enter bulstat: ");
        }

        public static void PrintAddressMessage()
        {
            Console.Write("Enter address: ");
        }

        public static void PrintEmailMessage()
        {
            Console.Write("Enter e-mail: ");
        }

        public static void PrintWebSiteMessage()
        {
            Console.Write("Enter website: ");
        }

        public static void PrintMobileNumberMessage()
        {
            Console.Write("Enter mobile number: ");
        }

        public static void PrintPhoneNumberMessage()
        {
            Console.Write("Enter phone number: ");
        }

        public static void PrintFaxMessage()
        {
            Console.Write("Enter fax number: ");
        }

        public static void PrintSectorMessage()
        {
            Console.Write("Enter sector: ");
        }

        public static void PrintBirthDateMessage()
        {
            Console.Write("Enter date of birth: ");
        }

        public static void PrintMiddleNameMessage()
        {
            Console.Write("Enter middle name: ");
        }

        public static void PrintLastNameMessage()
        {
            Console.Write("Enter family name: ");
        }

        public static void PrintOccupationMessage()
        {
            Console.Write("Enter occupation: ");
        }

        public static void PrintOrganizationMessage()
        {
            Console.Write("Enter organization: ");
        }

        public static void PrintBloodGroupMessage()
        {
            Console.Write("Enter blood group: ");
        }

        public static void PrintEgnMessage()
        {
            Console.Write("Enter EGN: ");
        }

        public static void PrintFamilyTreeMemberMessage()
        {
            Console.Write("Enter family tree member: ");
        }

        public static void PrintNicknameMessage()
        {
            Console.Write("Enter a nickname: ");
        }

        public static void PrintAttFilePathMessage()
        {
            Console.Write("Enter file path: ");
        }

        public static void PrintSendToMessage()
        {
            Console.Write("Enter e-mail receiver: ");
        }

        public static void PrintSubjectMessage()
        {
            Console.Write("Enter subject: ");
        }

        public static void PrintTextMessage()
        {
            Console.Write("Enter the text: ");
        }

        public static void PrintLocationMessage()
        {
            Console.Write("Enter a location: ");
        }

        public static void PrintProjectMessage()
        {
            Console.Write("Enter a project: ");
        }

        public static void PrintCategoryMessage()
        {
            Console.Write("Enter a category: ");
        }

        public static void WelcomeMessage()
        {
            Console.WriteLine("------------Organizer-Morticia Edition------------");
        }

        public static void PrintNameMessage()
        {
            Console.Write("Enter a name: ");
        }

        public static void PrintSelectFromMessage()
        {
            Console.WriteLine("Select from: ");
        }

        public static void PrintSelectMessage()
        {
            Console.Write("Select: ");
        }

        public static void PrintCommentMessage()
        {
            Console.Write("Enter a comment: ");
        }

        public static void PrintReminderMessage()
        {
            Console.Write("Enter a reminder message: ");
        }

        public static void PrintExitMenuItemMessage()
        {
            Console.Write("10. Exit!");
        }

        public static void PrintBackMenuItemMessage()
        {
            Console.Write("0. Back to previus menu");
        }
        #endregion
    }
}
