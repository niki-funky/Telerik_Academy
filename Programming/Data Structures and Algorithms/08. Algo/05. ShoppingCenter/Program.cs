using System;
using System.Linq;
using System.Text;

namespace _05.ShoppingCenter
{
    class Program
    {
        private const string AddProduct = "AddProduct";
        private const string DeleteProducts = "DeleteProducts";
        private const string FindProductsByName = "FindProductsByName";
        private const string FindProductsByPriceRange = "FindProductsByPriceRange";
        private const string FindProductsByProducer = "FindProductsByProducer";

        private static ProductRepository productRepository =
            new ProductRepository();
        private static StringBuilder result = new StringBuilder();

        static void Main(string[] args)
        {
#if DEBUG
            Console.SetIn(new System.IO.StreamReader("../../input.txt"));
#endif
            int n = int.Parse(Console.ReadLine());
            for (int i = 0; i < n; i++)
            {
                string inputLine = Console.ReadLine();
                var command = inputLine.Substring(0, inputLine.IndexOf(' '));
                var afterCommand = inputLine.Substring(inputLine.IndexOf(' ')).Trim();
                string[] data =
                    afterCommand.Split(new char[] { ';' },
                        StringSplitOptions.RemoveEmptyEntries);

                CommandManager(command, data);
            }

            Console.Write(result);
        }

        private static void CommandManager(string command, string[] data)
        {
            if (command == AddProduct)
            {
                var name = data[0];
                var price = double.Parse(data[1]);
                var producer = data[2];
                var product = new Product(name, price, producer);
                productRepository.AddProduct(product);
                Print("Product added");
            }
            else if (command == DeleteProducts)
            {
                if (data.Length == 1)
                {
                    var producer = data[0];
                    int result = productRepository.Delete(producer);
                    if (result == 0)
                    {
                        Print("No products found");
                    }
                    else
                    {
                        Print(string.Format("{0} products deleted", result));
                    }
                }
                else
                {
                    var name = data[0];
                    var producer = data[1];
                    int result = productRepository.Delete(name, producer);
                    if (result == 0)
                    {
                        Print("No products found");
                    }
                    else
                    {
                        Print(string.Format("{0} products deleted", result));
                    }
                }
            }
            else if (command == FindProductsByName)
            {
                var products = productRepository.FindProductsByName(data[0]);
                if (products.Count == 0)
                {
                    Print("No products found");
                }
                else
                {
                    foreach (var product in products)
                    {
                        Print(product.ToString());
                    }
                }
            }
            else if (command == FindProductsByPriceRange)
            {
                var from = double.Parse(data[0]);
                var to = double.Parse(data[1]);
                var products = productRepository.FindProductsByPriceRange(from, to);
                if (products.Count() == 0)
                {
                    Print("No products found");
                }
                else
                {
                    foreach (var product in products)
                    {
                        Print(product.ToString());
                    }
                }
            }
            else if (command == FindProductsByProducer)
            {
                var products = productRepository.FindProductsByProducer(data[0]);
                if (products.Count == 0)
                {
                    Print("No products found");
                }
                else
                {
                    foreach (var product in products)
                    {
                        Print(product.ToString());
                    }
                }
            }
        }

        private static void Print(string text)
        {
            result.AppendLine(text);
        }
    }
}
