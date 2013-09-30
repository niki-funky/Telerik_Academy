using System;
using System.Data.Entity;
using System.Linq;
using Twitter.Models;

namespace Twitter.Data
{
    interface IDataContext
    {
        IDbSet<Tag> Tags { get; set; }

        IDbSet<Tweet> Tweets { get; set; }
    }
}
