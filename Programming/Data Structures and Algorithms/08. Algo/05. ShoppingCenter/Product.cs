using System;
using System.Linq;
using System.Text;

namespace _05.ShoppingCenter
{
    public class Product : IComparable<Product>
    {
        public string Name { get; set; }

        public double Price { get; set; }

        public string Producer { get; set; }

        public Product(string name, double price, string producer)
        {
            this.Name = name;
            this.Price = price;
            this.Producer = producer;
        }

        public int CompareTo(Product other)
        {
            var result = this.Price.CompareTo(other.Price);

            return result;
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append('{');
            sb.Append(this.Name);
            sb.Append(';');
            sb.Append(this.Producer);
            sb.Append(';');
            sb.Append(string.Format("{0:F2}", this.Price));
            sb.Append('}');

            return sb.ToString();
        }
    }
}
