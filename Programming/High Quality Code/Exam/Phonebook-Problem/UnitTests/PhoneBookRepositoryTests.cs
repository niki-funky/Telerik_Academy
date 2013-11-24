namespace UnitTests
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using PhoneBook;

    [TestClass]
    public class PhoneBookRepositoryTests
    {
        [TestMethod]
        public void TestMethodAddPhoneWithSingleEntry()
        {
            PhoneBookRepository phoneBook = new PhoneBookRepository();
            string name = "Alpha";
            List<string> listOfPhoneNumbers = new List<string>{
                "+359111222333"
            };

            phoneBook.AddPhone(name, listOfPhoneNumbers);
            int phoneEntries = phoneBook.GetSortedPhoneBookCount();

            Assert.AreEqual(1, phoneEntries);
        }

        [TestMethod]
        public void TestMethodAddPhoneWithMultipleEntries()
        {
            PhoneBookRepository phoneBook = new PhoneBookRepository();

            string name1 = "Alpha";
            string name2 = "Beta";
            string name3 = "Gama";
            List<string> listOfPhoneNumbers = new List<string>{
                "+359111222333",
                "+359111222334"
            };

            phoneBook.AddPhone(name1, listOfPhoneNumbers);
            phoneBook.AddPhone(name2, listOfPhoneNumbers);
            phoneBook.AddPhone(name3, listOfPhoneNumbers);

            int phoneEntries = phoneBook.GetSortedPhoneBookCount();

            Assert.AreEqual(3, phoneEntries);
        }

        [TestMethod]
        public void TestMethodAddPhoneWithDuplicatedEntries()
        {
            PhoneBookRepository phoneBook = new PhoneBookRepository();

            string name1 = "Alpha";
            string name2 = "Beta";
            List<string> listOfPhoneNumbers = new List<string>{
                "+359111222333",
                "+359111222334"
            };

            phoneBook.AddPhone(name1, listOfPhoneNumbers);
            phoneBook.AddPhone(name2, listOfPhoneNumbers);
            phoneBook.AddPhone(name1, listOfPhoneNumbers);

            int phoneEntries = phoneBook.GetSortedPhoneBookCount();

            Assert.AreEqual(2, phoneEntries);
        }

        [TestMethod]
        public void TestMethodChangePhoneWithSingleEntry()
        {
            PhoneBookRepository phoneBook = new PhoneBookRepository();
            string name = "Alpha";
            string oldNumber = "+359111222333";
            string newNumber = "+359000000000";
            List<string> listOfPhoneNumbers = new List<string>{
                "+359111222333"
            };

            phoneBook.AddPhone(name, listOfPhoneNumbers);
            phoneBook.ChangePhone(oldNumber, newNumber);
            int phoneEntries = phoneBook.GetSortedPhoneBookCount();

            Assert.AreEqual(1, phoneEntries);
        }

        [TestMethod]
        public void TestMethodChangePhoneWithMultipleEntries()
        {
            PhoneBookRepository phoneBook = new PhoneBookRepository();

            string name1 = "Alpha";
            string name2 = "Beta";
            string oldNumber = "+359111222333";
            string newNumber = "+359000000000";
            List<string> listOfPhoneNumbers = new List<string>{
                "+359111222333",
                "+359111222334"
            };

            phoneBook.AddPhone(name1, listOfPhoneNumbers);
            phoneBook.AddPhone(name2, listOfPhoneNumbers);

            phoneBook.ChangePhone(oldNumber, newNumber);
            int phoneEntries = phoneBook.GetSortedPhoneBookCount();

            Assert.AreEqual(2, phoneEntries);
        }

        [TestMethod]
        public void TestMethodChangePhoneWithMultipleEntries2()
        {
            PhoneBookRepository phoneBook = new PhoneBookRepository();

            string name1 = "Alpha";
            string name2 = "Beta";
            string oldNumber = "+359111222333";
            string newNumber = "+359000000000";
            List<string> listOfPhoneNumbers = new List<string>{
                "+359111222333",
                "+359111222334"
            };

            phoneBook.AddPhone(name1, listOfPhoneNumbers);
            phoneBook.AddPhone(name2, listOfPhoneNumbers);

            phoneBook.ChangePhone(oldNumber, newNumber);
            phoneBook.ChangePhone(newNumber, oldNumber);
            phoneBook.ChangePhone(oldNumber, newNumber);
            phoneBook.ChangePhone(newNumber, oldNumber);

            int phoneEntries = phoneBook.GetSortedPhoneBookCount();

            Assert.AreEqual(2, phoneEntries);
        }

        [TestMethod]
        public void TestMethodListPhoneEntriesWithSingleEntry()
        {
            PhoneBookRepository phoneBook = new PhoneBookRepository();
            string name = "Alpha";
            int startIndex = 0;
            int numberOfEntriesToList = 1;
            List<string> listOfPhoneNumbers = new List<string>{
                "+359111222333"
            };

            phoneBook.AddPhone(name, listOfPhoneNumbers);
            var list = phoneBook.ListPhoneEntries(startIndex, numberOfEntriesToList);
            int numberOfEntries = list.Length;

            Assert.AreEqual(1, numberOfEntries);
        }

        [TestMethod]
        public void TestMethodListPhoneEntriesWithMultipleEntries1()
        {
            PhoneBookRepository phoneBook = new PhoneBookRepository();

            string name1 = "Alpha";
            string name2 = "Beta";
            int startIndex = 0;
            int numberOfEntriesToList = 2;
            List<string> listOfPhoneNumbers = new List<string>{
                "+359111222333",
                "+359111222334"
            };

            phoneBook.AddPhone(name1, listOfPhoneNumbers);
            phoneBook.AddPhone(name2, listOfPhoneNumbers);
            phoneBook.AddPhone(name1, listOfPhoneNumbers);

            var list = phoneBook.ListPhoneEntries(startIndex, numberOfEntriesToList);
            int numberOfEntries = list.Length;

            Assert.AreEqual(2, numberOfEntries);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void TestMethodListPhoneEntriesWithWrongCount()
        {
            PhoneBookRepository phoneBook = new PhoneBookRepository();
            string name = "Alpha";
            int startIndex = 0;
            int numberOfEntriesToList = 3;
            List<string> listOfPhoneNumbers = new List<string>{
                "+359111222333"
            };

            phoneBook.AddPhone(name, listOfPhoneNumbers);
            var list = phoneBook.ListPhoneEntries(startIndex, numberOfEntriesToList);
            int numberOfEntries = list.Length;

            Assert.AreEqual(1, numberOfEntries);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void TestMethodListPhoneEntriesWithWrongIndex()
        {
            PhoneBookRepository phoneBook = new PhoneBookRepository();
            string name = "Alpha";
            int startIndex = 10;
            int numberOfEntriesToList = 1;
            List<string> listOfPhoneNumbers = new List<string>{
                "+359111222333"
            };

            phoneBook.AddPhone(name, listOfPhoneNumbers);
            var list = phoneBook.ListPhoneEntries(startIndex, numberOfEntriesToList);
            int numberOfEntries = list.Length;

            Assert.AreEqual(1, numberOfEntries);
        }
    }
}
