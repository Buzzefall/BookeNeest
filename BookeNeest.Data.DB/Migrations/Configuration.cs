using System.Data.Entity.Migrations;

using BookeNeest.Data.DB.Context;

namespace BookeNeest.Data.DB.Migrations
{
    internal sealed partial class Configuration : DbMigrationsConfiguration<BookeNeestDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(BookeNeestDbContext dbContext)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data.
            SeedRolesAndUsers(dbContext);
            this.SeedBooks(dbContext, 30);
        }
    }
}