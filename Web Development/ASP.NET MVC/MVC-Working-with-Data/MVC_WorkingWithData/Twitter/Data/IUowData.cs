using Twitter.Models;
using System;
using System.Linq;

namespace Twitter.Data
{
    public interface IUowData : IDisposable
    {
        IRepository<Tag> Tags { get; }

        IRepository<Tweet> Tweets { get; }

        IRepository<ApplicationUser> Users { get; }

        int SaveChanges();
    }
}
