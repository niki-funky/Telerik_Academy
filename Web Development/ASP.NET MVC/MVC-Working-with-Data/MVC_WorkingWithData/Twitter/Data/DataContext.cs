using System;
using System.Data.Entity;
using System.Linq;
using Microsoft.AspNet.Identity.EntityFramework;
using Twitter.Models;

namespace Twitter.Data
{
    public class DataContext : IdentityDbContextWithCustomUser<ApplicationUser>
    {
        public IDbSet<Tweet> Tweets { get; set; }
        public IDbSet<Tag> Tags { get; set; }
    }
}