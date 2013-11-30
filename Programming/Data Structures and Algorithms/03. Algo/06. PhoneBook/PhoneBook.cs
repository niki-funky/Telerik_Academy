
namespace PhoneBook
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Wintellect.PowerCollections;

    class PhoneBook
    {
        public MultiDictionary<string, PhoneBookEntry> FirstNames { get; set; }
        public MultiDictionary<string, PhoneBookEntry> MiddleNames { get; set; }
        public MultiDictionary<string, PhoneBookEntry> LastNames { get; set; }
        public MultiDictionary<string, PhoneBookEntry> NickNames { get; set; }
        public MultiDictionary<string, PhoneBookEntry> Towns { get; set; }

        public PhoneBook()
        {
            FirstNames = new MultiDictionary<string, PhoneBookEntry>(true);
            MiddleNames = new MultiDictionary<string, PhoneBookEntry>(true);
            LastNames = new MultiDictionary<string, PhoneBookEntry>(true);
            NickNames = new MultiDictionary<string, PhoneBookEntry>(true);
            Towns = new MultiDictionary<string, PhoneBookEntry>(true);

        }

        public void Add(PhoneBookEntry entry)
        {
                FirstNames.Add(entry.FirstName, entry);
                MiddleNames.Add(entry.MiddleName, entry);
                LastNames.Add(entry.LastName, entry);
                NickNames.Add(entry.NickName, entry);
                Towns.Add(entry.Town, entry);
        }

        public List<PhoneBookEntry> Find(string name)
        {
            List<PhoneBookEntry> result = new List<PhoneBookEntry>();

            result.AddRange(FirstNames[name]);
            result.AddRange(MiddleNames[name]);
            result.AddRange(LastNames[name]);
            result.AddRange(NickNames[name]);

            return result;
        }

        public List<PhoneBookEntry> Find(string name, string town)
        {
            List<PhoneBookEntry> result = new List<PhoneBookEntry>();

            result.AddRange(FirstNames[name].Where(x => x.Town == town));
            result.AddRange(MiddleNames[name].Where(x => x.Town == town));
            result.AddRange(LastNames[name].Where(x => x.Town == town));
            result.AddRange(NickNames[name].Where(x => x.Town == town));

            return result;
        }
    }
}
