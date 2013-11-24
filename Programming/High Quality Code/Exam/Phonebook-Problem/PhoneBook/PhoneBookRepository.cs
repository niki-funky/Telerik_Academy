namespace PhoneBook
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Wintellect.PowerCollections;

    public class PhoneBookRepository : IPhonebookRepository
    {
        public List<PhoneEntry> PhoneBookEntries = new List<PhoneEntry>();

        public bool AddPhone(string name, IEnumerable<string> listOfNumbers)
        {
            var listWithOldNumbers = from e in this.PhoneBookEntries
                                     where e.Name.ToLowerInvariant() == name.ToLowerInvariant()
                                     select e;

            bool isNumberFound = false;
            PhoneEntry phoneEntry;
            var distinctItems = listOfNumbers.Distinct();

            // bottleneck 
            if (listWithOldNumbers.Count() == 0)
            {
                phoneEntry = new PhoneEntry();
                phoneEntry.Name = name;
                phoneEntry.ListOfNumbers = new SortedSet<string>();

                foreach (var number in distinctItems)
                {
                    phoneEntry.ListOfNumbers.Add(number);
                }

                this.PhoneBookEntries.Add(phoneEntry);

                isNumberFound = true;
            }
            else if (listWithOldNumbers.Count() == 1)
            {
                phoneEntry = listWithOldNumbers.First();
                foreach (var number in distinctItems)
                {
                    phoneEntry.ListOfNumbers.Add(number);
                }

                isNumberFound = false;
            }

            return isNumberFound;
        }

        public int ChangePhone(string oldNumber, string newNumber)
        {
            var list = (from e in this.PhoneBookEntries
                        where e.ListOfNumbers.Contains(oldNumber)
                        select e);

            int numberOfChangedNumbers = 0;
            foreach (var entry in list)
            {
                entry.ListOfNumbers.Remove(oldNumber);
                entry.ListOfNumbers.Add(newNumber);
                numberOfChangedNumbers++;
            }
            return numberOfChangedNumbers;
        }

        public PhoneEntry[] ListPhoneEntries(int startIndex, int count)
        {
            if (startIndex < 0 || startIndex + count > this.PhoneBookEntries.Count)
            {
                throw new ArgumentOutOfRangeException("Invalid start index or count.");
            }

            this.PhoneBookEntries.Sort();
            PhoneEntry[] listOfPhoneEntries = new PhoneEntry[count];

            for (int i = startIndex; i <= startIndex + count - 1; i++)
            {
                PhoneEntry entry = this.PhoneBookEntries[i];
                listOfPhoneEntries[i - startIndex] = entry;
            }

            return listOfPhoneEntries;
        }

        public int GetSortedPhoneBookCount()
        {
            return PhoneBookEntries.Count;
        }
    }
}
