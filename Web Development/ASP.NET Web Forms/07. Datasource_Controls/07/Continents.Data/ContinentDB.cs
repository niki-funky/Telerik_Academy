using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Continents.Models;

namespace Continents.Data
{
    public class ContinentDB : DbContext
    {
        public ContinentDB()
            : base("ContinentDB")
        {
            //Database.SetInitializer<ContinentDB>(new DropCreateDatabaseIfModelChanges<ContinentDB>());
        }

        public DbSet<Continent> Continents { get; set; }
        public DbSet<Country> Countries { get; set; }
        public DbSet<Town> Towns { get; set; }
    }
}
