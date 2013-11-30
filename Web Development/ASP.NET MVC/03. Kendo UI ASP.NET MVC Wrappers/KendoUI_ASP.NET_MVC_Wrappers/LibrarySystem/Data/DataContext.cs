using System;
using System.Data.Entity;
using System.Linq;
using Microsoft.AspNet.Identity.EntityFramework;
using LibrarySystem.Models;

namespace LibrarySystem.Data
{
    public class DataContext : IdentityDbContextWithCustomUser<ApplicationUser>
    {
        public IDbSet<Book> Books { get; set; }
        public IDbSet<Category> Categories { get; set; }
    }
}