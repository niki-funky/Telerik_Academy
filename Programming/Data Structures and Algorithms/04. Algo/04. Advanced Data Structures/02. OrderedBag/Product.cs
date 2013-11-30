using System;
using System.Linq;

namespace OrderedBag
{
    class Product : IComparable<Product>
    {
        private string name;
        private double price;

        public Product(string name,double price)
        {
            this.Name = name;
            this.Price = price;
        }

        public string Name
        {
            get
            {
                return this.name;
            }
            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentException("Name cannot be null or empty.");
                }
                this.name = value;
            }
        }

        public double Price
        {
            get
            {
                return this.price;
            }
            set
            {
                if (value <= 0)
                {
                    throw new ArgumentException("Price should be positive.");
                }
                this.price = value;
            }
        }

        public int CompareTo(Product other)
        {
            return this.price.CompareTo(other.price);
        }

        public override string ToString()
        {
            return string.Format("{0}: {1}", name, price);
        }
    }
}
