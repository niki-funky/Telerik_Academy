using System;
using System.Data.Entity;
using System.Linq;
using StudentSystem.Models;

namespace StudentSystem.Data
{
    public class StudentSystemContext : DbContext
    {
        public StudentSystemContext()
            : base("StudentSystemDB")
        {
        }

        public DbSet<Student> Students { get; set; }

        public DbSet<Course> Courses { get; set; }

        public DbSet<Material> Materials { get; set; }

        public DbSet<Homework> Homeworks { get; set; }

        //protected override void OnModelCreating(DbModelBuilder modelBuilder)
        //{
        //    modelBuilder.Entity<Tag>().HasKey(x => x.TagId);
        //    modelBuilder.Entity<Tag>().Property(x => x.Text).IsUnicode(true);
        //    modelBuilder.Entity<Tag>().Property(x => x.Text).HasMaxLength(255);
        //    //// modelBuilder.Entity<Tag>().Property(x => x.Text).IsFixedLength();

        //    //// modelBuilder.Configurations.Add(new TagMappings());

        //    base.OnModelCreating(modelBuilder);
        //}
    }
}
