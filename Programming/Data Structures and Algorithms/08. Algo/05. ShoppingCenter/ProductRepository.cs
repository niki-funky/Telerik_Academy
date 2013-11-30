using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wintellect.PowerCollections;

namespace _05.ShoppingCenter
{
    class ProductRepository
    {
        public MultiDictionary<string, Product> productsByName =
            new MultiDictionary<string, Product>(true);
        public MultiDictionary<string, Product> productsByProducer =
            new MultiDictionary<string, Product>(true);
        public OrderedBag<Product> productsByPrice = new OrderedBag<Product>();

        public void AddProduct(Product product)
        {
            productsByName.Add(product.Name, product);
            productsByProducer.Add(product.Producer, product);
            productsByPrice.Add(product);
        }

        public int Delete(string producer)
        {
            ICollection<Product> productsWithGivenProducer =
                productsByProducer[producer];
            var count = productsWithGivenProducer.Count;

            foreach (var product in productsWithGivenProducer)
            {
                productsByName.Remove(product.Name);
                productsByPrice.Remove(product);
            }
            productsByProducer.Remove(producer);

            return count;
        }

        public int Delete(string name, string producer)
        {
            var productsWithGivenName = new List<Product>(
                productsByName[name]);
            var temp = productsWithGivenName.TakeWhile(x => x.Producer == producer);
            var count = temp.Count();

            foreach (var product in temp)
            {
                productsByName.Remove(product.Name);
                productsByPrice.Remove(product);
                productsByProducer.Remove(producer);
            }

            return count;
        }

        public ICollection<Product> FindProductsByName(string name)
        {
            var result = productsByName[name];
            var res = new List<Product>(result);
            res.Sort();

            return res;
        }

        public IEnumerable<Product> FindProductsByPriceRange(double from, double to)
        {
            var result = productsByPrice.Range(
                new Product("searchItem", from, "searchItem"), true,
                new Product("searchItem", to, "searchItem"), true);
            var sorted = result
            .OrderBy(x => x.Name)
            .ThenBy(x => x.Producer)
            .ThenBy(x => x.Price);

            return sorted;
        }

        public ICollection<Product> FindProductsByProducer(string producer)
        {
            var result = productsByProducer[producer];
            var res = new List<Product>(result);
            res.Sort();

            return res;
        }
    }
}
