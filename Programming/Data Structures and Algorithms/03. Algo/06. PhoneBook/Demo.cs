
namespace PhoneBook
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text.RegularExpressions;

    class Demo
    {
        public static void Main()
        {
            try
            {
                var phonesPath = @"..\..\phones.txt";
                var commandsPath = @"..\..\commands.txt";
                var pattern = @"(?<=\().+?(?=\))";

                Dictionary<string, List<PhoneBookEntry>> result =
                    new Dictionary<string, List<PhoneBookEntry>>();
                PhoneBook phoneBook = new PhoneBook();

                ReadPhoneEntries(phonesPath, phoneBook);
                ReadCommands(commandsPath, pattern, phoneBook, result);
                PrintResult(result);
            }
            catch (ArgumentException aex)
            {
                Console.WriteLine(aex.Message);
            }
        }

        private static void ReadPhoneEntries(
            string path, PhoneBook phoneBook)
        {
            string line;
            using (System.IO.StreamReader reader = new System.IO.StreamReader(path))
            {
                while ((line = reader.ReadLine()) != null)
                {
                    PhoneBookEntry newEntry;
                    var phoneEntry = line.Split('|');

                    var name = phoneEntry[0].Trim().Split(' ');
                    var town = phoneEntry[1].Trim();
                    var phone = phoneEntry[2].Trim();
                    if (name.Length < 3)
                    {
                        newEntry = new PhoneBookEntry(town, phone, phoneEntry[0].Trim());
                    }
                    else
                    {
                        newEntry = new PhoneBookEntry(name[0], name[1], name[2], town, phone);
                    }

                    phoneBook.Add(newEntry);
                }
            }
        }

        private static void ReadCommands(
            string path, string pattern,
            PhoneBook phoneBook,
            Dictionary<string, List<PhoneBookEntry>> collection)
        {
            string line;
            using (System.IO.StreamReader reader = new System.IO.StreamReader(path))
            {
                while ((line = reader.ReadLine()) != null)
                {
                    var match = Regex.Match(line, pattern).ToString().Split(',');
                    string name = match[0];
                    if (match.Length > 1)
                    {
                        string town = match[1].Trim();
                        collection.Add(name, phoneBook.Find(name, town));
                    }
                    else
                    {
                        collection.Add(name, phoneBook.Find(name));
                    }
                }
            }
        }

        private static void PrintResult(
            Dictionary<string, List<PhoneBookEntry>> collection)
        {
            foreach (var item in collection)
            {
                Console.WriteLine("Result for(" + item.Key + "): ");
                foreach (var phoneEntry in item.Value)
                {
                    Console.WriteLine(phoneEntry.ToString());
                }
            }
        }
    }
}
