namespace SortingAlgoritmsTests
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using SortingHomework;

    [TestClass]
    public class SelectionSortTests
    {
        private static SelectionSorter<int> sorter;

        [ClassInitialize]
        public static void InitilizeSelectionSorter(TestContext context)
        {
            sorter = new SelectionSorter<int>();
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void SortNullCollectionTest()
        {
            sorter.Sort(null);
        }

        [TestMethod]
        public void SortRandomCollectionTest()
        {
            SortableCollection<int> collection =
                new SortableCollection<int>(GenerateSorted(100));

            collection.Shuffle();
            collection.Sort(sorter);

            Assert.IsTrue(IsSorted(collection.Items));
        }

        [TestMethod]
        public void SortSortedCollectionTest()
        {
            SortableCollection<int> collection =
                new SortableCollection<int>(GenerateSorted(100));

            collection.Sort(sorter);

            Assert.IsTrue(IsSorted(collection.Items));
        }

        [TestMethod]
        public void SortReversedCollectionTest()
        {
            SortableCollection<int> collection =
                 new SortableCollection<int>(GenerateReversed(100));

            collection.Sort(sorter);

            Assert.IsTrue(IsSorted(collection.Items));
        }

        private static bool IsSorted(IList<int> collection)
        {
            for (int i = 0; i < collection.Count - 1; i++)
            {
                if (collection[i] > collection[i + 1])
                {
                    return false;
                }
            }

            return true;
        }

        private static List<int> GenerateSorted(int items)
        {
            List<int> sortedList = new List<int>();

            for (var i = 0; i < items; i++)
            {
                sortedList.Add(i);
            }

            return sortedList;
        }

        private static List<int> GenerateReversed(int items)
        {
            List<int> reversedList = new List<int>();

            for (var i = items; i > 0; i--)
            {
                reversedList.Add(i);
            }

            return reversedList;
        }
    }
}
