namespace LibrarySystem.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using LibrarySystem.Data;
    using LibrarySystem.Models;
    using Microsoft.AspNet.Identity.EntityFramework;

    internal sealed class Configuration : DbMigrationsConfiguration<DataContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
            this.AutomaticMigrationDataLossAllowed = true;
        }

        protected override void Seed(DataContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data. E.g.
            //
            //    context.People.AddOrUpdate(
            //      p => p.FullName,
            //      new Person { FullName = "Andrew Peters" },
            //      new Person { FullName = "Brice Lambson" },
            //      new Person { FullName = "Rowan Miller" }
            //    );
            //

            if (!context.Roles.Any(r => r.Name == "Admin"))
            {
                context.Roles.AddOrUpdate(new Role("Admin"));
            }

            //if (Membership.GetUser("admin", false) == null)
            //{
            //    Membership.CreateUser("admin", "123456");
            //}
            //if (!context..Roles.GetRolesForUser("admin").Contains("Admin"))
            //{
            //    Roles.AddUsersToRoles(new[] { "admin" }, new[] { "Admin" });
            //}
            context.SaveChanges();
        }
    }
}
