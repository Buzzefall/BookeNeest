using System.Data.Entity.Migrations;

namespace BookeNeest.Data.DB.Migrations
{
    internal sealed partial class Configuration : DbMigrationsConfiguration<BookeNeest.Data.DB.Context.BookeNeestDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(BookeNeest.Data.DB.Context.BookeNeestDbContext dbContext)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data.
            SeedRolesAndUsers(dbContext);
        }
    }
}