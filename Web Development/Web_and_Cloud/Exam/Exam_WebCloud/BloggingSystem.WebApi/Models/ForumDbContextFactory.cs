using System;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using BloggingSystem.DataLayer;

namespace BloggingSystem.WebApi.Models
{
    public class ForumDbContextFactory:IDbContextFactory<DbContext>
    {
        public DbContext Create()
        {
            return new BloggingSystemContext();
        }
    }
}