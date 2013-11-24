//-----------------------------------------------------------------------
// <copyright file="CatalogTests.cs" company="TelerikAcademy">
//     All rights reserved © Telerik Academy 2012-2013
// </copyright>
//----------------------------------------------------------------------
namespace UnitTests
{
    using System;
    using System.Linq;
    using CatalogOfFreeContent;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public class CatalogTests
    {
        [TestMethod]
        public void TestConstructor()
        {
            Catalog catalog = new Catalog();
            string[] parameters = new string[4];
            parameters[0] = null;
            parameters[1] = null;
            parameters[2] = "3";
            parameters[3] = null;

            CatalogContent catalogContent = new CatalogContent(ContentTypes.Application, parameters);
        }

        [TestMethod]
        public void TestMethodGetListContent1()
        {
            Catalog catalog = new Catalog();
            string[] parameters = new string[] { "Academy", "Telerik", "3", "http://telerikacademy.com/" };
            CatalogContent item = new CatalogContent(ContentTypes.Movie, parameters);
            catalog.Add(item);
            var result = catalog.GetListContent("Academy", 3);

            Assert.AreEqual(result.Count(), 1);
        }

        [TestMethod]
        public void TestMethodGetListContent2()
        {
            Catalog catalog = new Catalog();
            string[] parameters = new string[] { "Academy", "Telerik", "3", "http://telerikacademy.com/" };
            CatalogContent item = new CatalogContent(ContentTypes.Movie, parameters);
            catalog.Add(item);
            var result = catalog.GetListContent("Gosho", 3);

            Assert.AreEqual(result.Count(), 0);
        }

        [TestMethod]
        public void TestMethodAddSingleItem()
        {
            Catalog catalog = new Catalog();
            string[] parameters = new string[] { "Academy", "Telerik", "3", "http://telerikacademy.com/" };
            CatalogContent item = new CatalogContent(ContentTypes.Movie, parameters);
            catalog.Add(item);
            var result = catalog.GetTitlesList();

            Assert.AreEqual(result.Count(), 1);
        }

        [TestMethod]
        public void TestMethodAddMultipleItems1()
        {
            Catalog catalog = new Catalog();
            string[] parameters1 = new string[] { "Academy", "Telerik", "3", "http://telerikacademy.com/" };
            string[] parameters2 = new string[] { "Academy", "Telerik", "3", "http://telerikacademy.com/cources/" };

            CatalogContent item1 = new CatalogContent(ContentTypes.Movie, parameters1);
            CatalogContent item2 = new CatalogContent(ContentTypes.Movie, parameters2);
            catalog.Add(item1);
            catalog.Add(item2);

            var result = catalog.GetTitlesList().KeyValuePairs;

            Assert.AreSame(result.Last().Value, item2);
        }

        [TestMethod]
        public void TestMethodAddMultipleItems2()
        {
            Catalog catalog = new Catalog();
            string[] parameters1 = new string[] { "Academy", "Telerik", "3", "http://telerikacademy.com/" };

            CatalogContent item1 = new CatalogContent(ContentTypes.Movie, parameters1);
            catalog.Add(item1);
            catalog.Add(item1);

            var result = catalog.GetTitlesList().KeyValuePairs;

            Assert.AreEqual(result.Count, 2);
        }

        [TestMethod]
        public void TestMethodAddMultipleItems3()
        {
            Catalog catalog = new Catalog();
            string[] parameters1 = new string[] { "Academy", "Telerik", "3", "http://telerikacademy.com/" };
            string[] parameters2 = new string[] { "Academy", "Telerik", "3", "http://telerikacademy.com/cources/" };

            CatalogContent item1 = new CatalogContent(ContentTypes.Movie, parameters1);
            CatalogContent item2 = new CatalogContent(ContentTypes.Movie, parameters2);
            catalog.Add(item1);
            catalog.Add(item2);

            var result = catalog.GetURLsList().KeyValuePairs;

            Assert.AreSame(result.First().Value, item2);
        }

        [TestMethod]
        public void TestMethodUpdateContentSingleitem()
        {
            Catalog catalog = new Catalog();
            string firstURL = "http://telerikacademy.com/";
            string secondURL = "http://telerikacademy.com/cources/";
            string[] parameters1 = new string[] { "Academy", "Telerik", "3", firstURL };
            string[] parameters2 = new string[] { "Academy", "Telerik", "3", secondURL };

            CatalogContent item1 = new CatalogContent(ContentTypes.Movie, parameters1);
            CatalogContent item2 = new CatalogContent(ContentTypes.Movie, parameters2);
            catalog.Add(item1);
            catalog.Add(item2);

            var result = catalog.UpdateContent(firstURL, secondURL);

            Assert.AreEqual(result, 1);
        }

        [TestMethod]
        public void TestMethodUpdateContentMultipleItems()
        {
            Catalog catalog = new Catalog();
            string firstURL = "http://telerikacademy.com/";
            string secondURL = "http://telerikacademy.com/cources/";
            string[] parameters1 = new string[] { "Academy", "Telerik", "3", firstURL };
            string[] parameters2 = new string[] { "Academy", "Telerik", "3", secondURL };

            CatalogContent item1 = new CatalogContent(ContentTypes.Movie, parameters1);
            CatalogContent item2 = new CatalogContent(ContentTypes.Movie, parameters2);
            catalog.Add(item1);
            catalog.Add(item1);
            catalog.Add(item1);
            catalog.Add(item2);

            var result = catalog.UpdateContent(firstURL, secondURL);

            Assert.AreEqual(result, 3);
        }
    }
}
