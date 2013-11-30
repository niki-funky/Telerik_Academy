using System;
using System.Data.Entity;
using System.Linq;
using ToDos.Models;

namespace ToDos.Data
{
    public class ToDosDB : DbContext
    {
        public ToDosDB()
            : base("TodosDB")
        {
            //Database.SetInitializer<ToDosDB>(new DropCreateDatabaseIfModelChanges<ToDosDB>());
        }

        public DbSet<Category> Categories { get; set; }
        public DbSet<Todo> Todos { get; set; }
    }
}
