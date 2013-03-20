using OrganizerClassLibrary.Enums;
using OrgaznizerClassLibrary.Structs;
using System;
using System.Collections.Generic;
using System.Linq;

namespace OrganizerClassLibrary
{
    public class OrganizerCore
    {
        //SingleTon
        private static readonly OrganizerCore instance = new OrganizerCore();

        private List<Contact> contacts;
        private List<Event> events;
        private List<Email> emails;
        private ObjectCounter counter;

        public static OrganizerCore GetOrganizerCoreInstance()
        {
            return instance;
        }

        private OrganizerCore()
        {
            contacts = new List<Contact>();
            events = new List<Event>();
            emails = new List<Email>();
            counter = new ObjectCounter();
        }

        #region Public Methods

        public void AddObject(OrganizerObject obj)
        {
            if (obj is Contact)
            {
                this.contacts.Add(obj as Contact);
                counter.IncreaseContacts();
            }
            else if (obj is Event)
            {
                this.events.Add(obj as Event);
                counter.IncreaseEvents();
            }
            else if (obj is Email)
            {
                this.emails.Add(obj as Email);
                counter.IncreaseEmails();
            }
        }

        public void PrintTotalObjectsCreated()
        {
            Console.WriteLine("-------------------------");
            Console.WriteLine("Contacts created: {0}", counter.Contacts);
            Console.WriteLine("Events created: {0}", counter.Events);
            Console.WriteLine("Emails created: {0}", counter.Emails);
        }

        public void RemoveObject(OrganizerObject obj)
        {
            if (obj is Contact)
            {
                //TODO: filter the contacts first.
                this.contacts.Remove(obj as Contact);
            }
            else if (obj is Event)
            {
                this.events.Remove(obj as Event);
            }
            if (obj is Email)
            {
                this.emails.Remove(obj as Email);
            }
        }

        public List<OrganizerObject> FindByName(List<OrganizerObject> objList, string name)
        {
            var result = objList.FindAll(contact => contact.Name == name);

            return result;
        }

        //TODO: Sort by what? first it is need it to ask by using the if statement, and implement the different types of sorts
        public List<Person> Sorted(List<Person> listObj, string property)
        {
            return listObj.OrderBy(x => x.Name).ToList();

        }

        public static void Initialize(OrganizerCore core)
        {
            Category category = new Category("to-do", color: OrganizerClassLibrary.Enums.Color.Magenta);
            category = new Category("Sport", color: Color.DarkGreen);
            category = new Category("Tasks", color: Color.DarkBlue);
            category = new Category("Personal", color: Color.Blue);
            category = new Category("Business", color: Color.DarkRed);
            category = new Category("Call", color: Color.Green);
            category = new Category("Shopping", color: Color.DarkMagenta);
            category = new Category("Idea", color: Color.DarkYellow);
        }

        #endregion
    }
}
