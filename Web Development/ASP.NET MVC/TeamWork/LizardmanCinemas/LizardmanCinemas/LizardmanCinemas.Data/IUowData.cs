using System;
using System.Linq;
using LizardmanCinemas.Models;
using System.Data.Entity;

namespace LizardmanCinemas.Data
{
    public interface IUowData : IDisposable
    {
        IRepository<Movie> Movies { get; }
        IRepository<Category> Categories { get; }
        IRepository<Actor> Actors { get; }
        IRepository<Director> Directors { get; }
        IRepository<Country> Country { get; }
        IRepository<Comment> Comments { get; }

        IRepository<Vote> Votes { get; }

        IRepository<ApplicationUser> Users { get; }

        DbContext GetContext();

        int SaveChanges();
    }
}
