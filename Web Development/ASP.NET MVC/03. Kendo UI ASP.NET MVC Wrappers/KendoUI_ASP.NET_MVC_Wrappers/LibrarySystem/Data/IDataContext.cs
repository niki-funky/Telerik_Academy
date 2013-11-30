using System;
using System.Data.Entity;
using System.Linq;
using LibrarySystem.Models;

namespace LibrarySystem.Data
{
    interface IDataContext
    {
        IDbSet<Book> Books { get; set; }

        IDbSet<Category> Categories { get; set; }
    }
}
