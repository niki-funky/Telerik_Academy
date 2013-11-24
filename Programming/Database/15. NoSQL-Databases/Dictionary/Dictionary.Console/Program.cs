using System;
using System.Linq;
using MongoDB.Driver;
using MongoDB.Driver.Linq;
using Dictionary.Data;
using Dictionary.Data.Library;

namespace Dictionary.Console
{
    class Program
    {
        static void Main(string[] args)
        {
            var dbSearch = LoadData<Word>().ToList();
        }

        private static IQueryable<T> LoadData<T>()
        {
            try
            {
                return MongoDbProvider.db.GetCollection<T>(typeof(T).Name).AsQueryable();
            }
            catch (MongoConnectionException ex)
            {
                throw new MongoCommandException("Cannot access database. Please try again later");
            }
        }
    }
}
