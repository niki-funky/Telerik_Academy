using LibrarySystem.Models;
using System;
using System.Linq;

namespace LibrarySystem.Data
{
    public interface IUowData : IDisposable
    {
        IRepository<Book> Books { get; }

        IRepository<Category> Categories { get; }

        IRepository<ApplicationUser> Users { get; }

        int SaveChanges();
    }
}
