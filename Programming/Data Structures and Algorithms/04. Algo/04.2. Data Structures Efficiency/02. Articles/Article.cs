using System;
using System.Linq;

namespace Articles
{
    public class Article : IComparable
    {
        public string Barcode { get; set; }

        public string Vendor { get; set; }

        public string Title { get; set; }

        public double Price { get; set; }

        public Article(string barcode, string vendor, 
            string title, double price)
        {
            this.Barcode = barcode;
            this.Vendor = vendor;
            this.Title = title;
            this.Price = price;
        }

        public int CompareTo(object obj)
        {
            Article other = obj as Article;
            var result = this.Price.CompareTo(other.Price);

            return result;
        }
    }
}
