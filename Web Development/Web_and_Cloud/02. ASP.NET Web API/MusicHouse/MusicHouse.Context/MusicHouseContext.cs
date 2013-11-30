using System;
using System.Linq;
using System.Data.Entity;
using MusicHouse.Models;

namespace MusicHouse.Context
{
    public class MusicHouseContext : DbContext
    {
        public MusicHouseContext()
            : base("MusicHouseDb")
        {            
        }

        public DbSet<Album> Albums { get; set; }
        public DbSet<Artist> Artists { get; set; }
        public DbSet<Song> Songs { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Artist>().Property(x => x.Name).IsRequired();

            modelBuilder.Entity<Song>()
                .HasRequired(x => x.Album)
                .WithMany(d=>d.Songs)
                .WillCascadeOnDelete(true);

            //// modelBuilder.Entity<Tag>().Property(x => x.Text).IsFixedLength();

            //// modelBuilder.Configurations.Add(new TagMappings());

            base.OnModelCreating(modelBuilder);
        }
    }
}
