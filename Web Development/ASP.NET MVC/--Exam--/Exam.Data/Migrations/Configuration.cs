namespace Exam.Data.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using Microsoft.AspNet.Identity.EntityFramework;

    public sealed class Configuration : DbMigrationsConfiguration<ApplicationDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
            AutomaticMigrationDataLossAllowed = true;
        }

        protected override void Seed(ApplicationDbContext context)
        {
            //// Unique Constraints
            //context.Database.ExecuteSqlCommand(
            //    "IF OBJECT_ID('uc_Actors_FullName', 'UQ') IS NULL" +
            //    " ALTER TABLE Actors ADD CONSTRAINT uc_Actors_FullName UNIQUE(FirstName, LastName)");

            //context.Database.ExecuteSqlCommand(
            //    "IF OBJECT_ID('uc_Directors_FullName', 'UQ') IS NULL" +
            //    " ALTER TABLE Directors ADD CONSTRAINT uc_Directors_FullName UNIQUE(FirstName, LastName)");

            //context.Database.ExecuteSqlCommand(
            //    "IF OBJECT_ID('uc_Movies_Details', 'UQ') IS NULL" +
            //    " ALTER TABLE Movies ADD CONSTRAINT uc_Movies_Details UNIQUE(Title, Year)");

            //context.Database.ExecuteSqlCommand(
            //    "IF OBJECT_ID('uc_Categories_Name', 'UQ') IS NULL" +
            //    " ALTER TABLE Categories ADD CONSTRAINT uc_Categories_Name UNIQUE(Name)");


            //context.Database.ExecuteSqlCommand(
            //    "IF OBJECT_ID('uc_Countries_Name', 'UQ') IS NULL" +
            //    " ALTER TABLE Countries ADD CONSTRAINT uc_Countries_Name UNIQUE(Name)");

            if (!context.Roles.Any(r => r.Name == "Admin"))
            {
                context.Roles.AddOrUpdate(new Role("Admin"));
            }
            context.SaveChanges();
        }
    }
}
