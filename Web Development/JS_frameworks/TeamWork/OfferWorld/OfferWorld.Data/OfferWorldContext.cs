﻿using OfferWorld.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OfferWorld.Data
{
    public class OfferWorldContext : DbContext
    {
        public OfferWorldContext()
            : base("OfferWorldDb")
        {
            //Database.SetInitializer<OfferWorldContext>(new CreateDatabaseIfNotExists<OfferWorldContext>());
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Item> Items{ get; set; }
        public DbSet<Comment> Comments { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Offer> Offers { get; set; }
        public DbSet<Picture> Pictures { get; set; }
        public DbSet<DropboxAuthentication> DropboxAuthentication { get; set; }
    }
}
