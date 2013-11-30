namespace SearchAlgorithmsTests
{
    using System;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using SortingHomework;

    [TestClass]
    public class LinearSearchTests
    {
        [TestMethod]
        public void SearchNonExistingItemTest()
        {
            int[] items = new int[]
            { 
                8896, -8836, -9773, 3602, 5869, -109, -8428, 
                7009,  2174, -514, -3288, 5600, -462,
                -8249, -6084, 7916, -1277, 4929, -3135, -3450
            };
            SortableCollection<int> collection = new SortableCollection<int>(items);

            bool isFound = collection.LinearSearch(100000);

            Assert.IsFalse(isFound);
        }

        [TestMethod]
        public void SearchExistingItemTest1()
        {
            int[] items = new int[]
            { 
                8896, -8836, -9773, 3602, 5869, -109, -8428, 
                7009,  2174, -514, -3288, 5600, -462,
                -8249, -6084, 7916, -1277, 4929, -3135, -3450
            };
            SortableCollection<int> collection = new SortableCollection<int>(items);

            bool isFound = collection.LinearSearch(-1277);

            Assert.IsTrue(isFound);
        }

        [TestMethod]
        public void SearchExistingItemTest2()
        {
            int[] items = new int[]
            { 
                8896, -8836, -9773, 3602, 5869, -109, -8428, 
                7009,  2174, -514, -3288, 5600, -462,
                -8249, -6084, 7916, -1277, 4929, -3135, -3450
            };
            SortableCollection<int> collection = new SortableCollection<int>(items);

            bool isFound = collection.LinearSearch(4929);

            Assert.IsTrue(isFound);
        }
    }
}
