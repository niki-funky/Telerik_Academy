//-----------------------------------------------------------------------
// <copyright file="Catalog.cs" company="TelerikAcademy">
//     All rights reserved © Telerik Academy 2012-2013
// </copyright>
//----------------------------------------------------------------------
namespace CatalogOfFreeContent
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Wintellect.PowerCollections;

    /// <summary>
    /// Represents catalog that stores different types of content.
    /// </summary>
    public class Catalog : ICatalog
    {
        private readonly MultiDictionary<string, IContent> urls;
        private readonly OrderedMultiDictionary<string, IContent> titles;

        public Catalog()
        {
            bool allowDuplicateValues = true;
            this.titles = new OrderedMultiDictionary<string, IContent>(allowDuplicateValues);
            this.urls = new MultiDictionary<string, IContent>(allowDuplicateValues);
        }

        public void Add(IContent content)
        {
            this.titles.Add(content.Title, content);
            this.urls.Add(content.URL, content);
        }

        public IEnumerable<IContent> GetListContent(string title, int numberOfContentElementsToList)
        {
            // Bottleneck
            IEnumerable<IContent> contentToList = from c in this.titles[title]
                                                  select c;
            return contentToList.Take(numberOfContentElementsToList);
        }

        public int UpdateContent(string oldUrl, string newUrl)
        {
            int updatedItems = 0;
            // Bottleneck
            List<IContent> contentToList = this.urls[oldUrl].ToList();
            foreach (CatalogContent content in contentToList)
            {
                this.titles.Remove(content.Title, content);
                updatedItems++;
            }

            this.urls.Remove(oldUrl);

            foreach (IContent content in contentToList)
            {
                content.URL = newUrl;
            }

            foreach (IContent content in contentToList)
            {
                this.titles.Add(content.Title, content);
                this.urls.Add(content.URL, content);
            }

            return updatedItems;
        }

        public OrderedMultiDictionary<string, IContent> GetTitlesList()
        {
            return this.titles;
        }

        public MultiDictionary<string, IContent> GetURLsList()
        {
            return this.urls;
        }
    }
}
