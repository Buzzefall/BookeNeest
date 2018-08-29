using System.Data.Entity.Migrations;

namespace BookeNest.Data.DB.Migrations
{
    internal sealed partial class Configuration : DbMigrationsConfiguration<BookeNest.Data.DB.Context.BookeNestDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(BookeNest.Data.DB.Context.BookeNestDbContext dbContext)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data.
            SeedRolesAndUsers(dbContext);
        }
    }
}