using System;
using System.Data.Entity;
using System.Linq;
using LizardmanCinemas.Models;
using Microsoft.AspNet.Identity.EntityFramework;

namespace LizardmanCinemas.Data
{
    public class DataContext : IdentityDbContextWithCustomUser<ApplicationUser>
    {
        public IDbSet<Movie> Movies { get; set; }

        public IDbSet<Category> Categories { get; set; }

        public IDbSet<Actor> Actors { get; set; }

        public IDbSet<Director> Directors { get; set; }

        public IDbSet<Country> Country { get; set; }

        public IDbSet<Comment> Comments { get; set; }

        public IDbSet<Vote> Votes { get; set; }
    }
}