namespace PhoneBook
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    internal class CommandExecutor
    {
        private const string Code = "+359";
        private const string AddPhone = "AddPhone";
        private const string ChangePhone = "ChangePhone";
        private const string List = "List";

        private static IPhonebookRepository phoneBook = new PhoneBookRepository(); // this works!
        private static StringBuilder result = new StringBuilder();

        internal static void Main()
        {
            while (true)
            {
                string inputLine = Console.ReadLine();
                if (inputLine == "End" || inputLine == null)
                {
                    break;
                }

                int indexOfFirstBracket = inputLine.IndexOf('(');
                int phonesAsStringLength = inputLine.Length - indexOfFirstBracket - 2;

                string phonesAsString = inputLine.Substring(indexOfFirstBracket + 1, phonesAsStringLength);
                string[] phoneEntry = phonesAsString.Split(',');
                for (int j = 0; j < phoneEntry.Length; j++)
                {
                    phoneEntry[j] = phoneEntry[j].Trim();
                }

                if (phoneEntry.Length < 1)
                {
                    throw new ArgumentOutOfRangeException("There must be at least one phone for this entry!");
                }

                string command = inputLine.Substring(0, indexOfFirstBracket);
                if (command == AddPhone)
                {
                    CommandManager(AddPhone, phoneEntry);
                }
                else if (command == ChangePhone)
                {
                    CommandManager(ChangePhone, phoneEntry);
                }
                else if (command == List)
                {
                    CommandManager(List, phoneEntry);
                }
                else
                {
                    throw new InvalidOperationException("Invalid command!");
                }
            }

            Console.Write(result);
        }

        private static void CommandManager(string command, string[] phoneEntry)
        {
            if (command == AddPhone)
            {
                string name = phoneEntry[0];
                var phonesList = phoneEntry.Skip(1).ToList();
                for (int i = 0; i < phonesList.Count; i++)
                {
                    phonesList[i] = PhoneNumberParser(phonesList[i]);
                }

                bool isPhoneEntryAdded = phoneBook.AddPhone(name, phonesList);

                if (isPhoneEntryAdded)
                {
                    Print("Phone entry created");
                }
                else
                {
                    Print("Phone entry merged");
                }
            }
            else if (command == ChangePhone)
            {
                string oldNumber = PhoneNumberParser(phoneEntry[0]);
                string newNumber = PhoneNumberParser(phoneEntry[1]);
                int phonesChanged = phoneBook.ChangePhone(oldNumber, newNumber);
                Print(phonesChanged + " numbers changed");
            }
            else
            {
                try
                {
                    int startIndex = int.Parse(phoneEntry[0]);
                    int count = int.Parse(phoneEntry[1]);
                    IEnumerable<PhoneEntry> phoneEntries = phoneBook.ListPhoneEntries(startIndex, count);
                    foreach (var entry in phoneEntries)
                    {
                        Print(entry.ToString());
                    }
                }
                catch (ArgumentOutOfRangeException)
                {
                    Print("Invalid range");
                }
            }
        }

        private static string PhoneNumberParser(string phoneNumber)
        {
            StringBuilder output = new StringBuilder();
            //for (int i = 0; i <= result.Length; i++)
            //{
                output.Clear();

                foreach (char digit in phoneNumber)
                {
                    if (char.IsDigit(digit) || (digit == '+'))
                    {
                        output.Append(digit);
                    }
                }

                if (output.Length >= 2 && output[0] == '0' && output[1] == '0')
                {
                    output.Remove(0, 2);
                    output[0] = '+';
                }

                while (output.Length > 0 && output[0] == '0')
                {
                    output.Remove(0, 1);
                }

                if (output.Length > 0 && output[0] != '+')
                {
                    output.Insert(0, Code);
                }
            //}
            return output.ToString();
        }

        private static void Print(string text)
        {
            result.AppendLine(text);
        }
    }
}
