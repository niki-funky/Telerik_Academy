using System;
using System.Linq;
using System.Net.Http;
using Newtonsoft.Json;

namespace ConsumingWebServices
{
    class Program
    {
        static readonly HttpClient client = new HttpClient()
        {
            BaseAddress = new Uri("http://api.feedzilla.com/v1/articles/")
        };

        static void Main(string[] args)
        {
            Console.Write("Enter some string to search: ");
            var searchQuery = Console.ReadLine();
            Console.Write("Enter number of articles to retrieve: ");
            var numberOfArticles = int.Parse(Console.ReadLine());
            GetArticle(searchQuery, numberOfArticles);

            // due to async query, this is needed
            Console.ReadLine();
        }

        static async void GetArticle(string query, int count)
        {
            var response = await client.GetAsync("search.json?q=" + query + "&count=" + count);
            var json = await response.Content.ReadAsStringAsync();
            var result = JsonConvert.DeserializeObject<Articles>(json);

            Console.WriteLine(string.Join(Environment.NewLine,
                result.articles.Select(
                    article => String.Format(
                        "Article: {0}{1}URL: {2}{3}",
                        article.title,
                        Environment.NewLine,
                        article.url,
                        Environment.NewLine))));
        }
    }
}
