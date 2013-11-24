//-----------------------------------------------------------------------
// <copyright file="ICatalog.cs" company="TelerikAcademy">
//     All rights reserved © Telerik Academy 2012-2013
// </copyright>
//----------------------------------------------------------------------
namespace CatalogOfFreeContent
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public interface ICatalog
    {
        /// <summary>
        /// Adds a content to the catalog.
        /// </summary>
        /// <param name="content">Content to be added to the catalog.</param>
        void Add(IContent content);

        /// <summary>
        /// Finds all content items in the catalog that
        /// match the specified title.
        /// </summary>
        /// <param name="title">Title of an item to search for.</param>
        /// <param name="numberOfContentElementsToList">The maximal number of items to return.</param>
        /// <returns>List with items, matching the given title.</returns>
        /// <remarks>This method can return less then all items in the <paramref name=="numberOfContentElementsToList"/> parameter.</remarks>
        IEnumerable<IContent> GetListContent(string title, int numberOfContentElementsToList);

        /// <summary>
        /// Updates catalog items containing given URL,
        /// with items with another URL.
        /// </summary>
        /// <param name="oldUrl">URL of an item to search for.</param>
        /// <param name="newUrl">URL of the new items.</param>
        /// <returns>Number of updated items.</returns>
        int UpdateContent(string oldUrl, string newUrl);
    }
}
