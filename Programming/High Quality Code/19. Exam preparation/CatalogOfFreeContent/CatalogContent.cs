//-----------------------------------------------------------------------
// <copyright file="CatalogContent.cs" company="TelerikAcademy">
//     All rights reserved © Telerik Academy 2012-2013
// </copyright>
//----------------------------------------------------------------------
namespace CatalogOfFreeContent
{
    using System;
    using System.Linq;

    /// <summary>
    /// Represents the content of a catalog.
    /// </summary>
    public class CatalogContent : IComparable, IContent
    {
        private string url;

        public CatalogContent(ContentTypes type, string[] commandParams)
        {
            this.Type = type;
            this.Title = commandParams[(int)ItemData.Title];
            this.Author = commandParams[(int)ItemData.Author];
            this.Size = long.Parse(commandParams[(int)ItemData.Size]);
            this.URL = commandParams[(int)ItemData.Url];
        }

        public string Title { get; set; }

        public string Author { get; set; }

        public long Size { get; set; }

        public string URL
        {
            get
            {
                return this.url;
            }
            set
            {
                this.url = value;
                this.TextRepresentation = this.ToString();
            }
        }

        public ContentTypes Type { get; set; }

        public string TextRepresentation { get; set; }

        public int CompareTo(object obj)
        {
            if (null == obj)
            {
                return 1;
            }

            CatalogContent otherContent = obj as CatalogContent;
            if (otherContent != null)
            {
                int comparisonResult = 
                    this.TextRepresentation.CompareTo(otherContent.TextRepresentation);

                return comparisonResult;
            }

            throw new ArgumentException("Can not compare object with non-object.");
        }

        public override string ToString()
        {
            string output = String.Format(
                "{0}: {1}; {2}; {3}; {4}", 
                this.Type.ToString(), 
                this.Title, 
                this.Author, 
                this.Size, 
                this.URL);

            return output;
        }
    }
}
