using System.Data.Entity;
using BookeNeest.Data.DB.Context;
using BookeNeest.Data.DB.Migrations;

namespace BookeNeest.Data.DB
{
    internal class DbInitializer : MigrateDatabaseToLatestVersion<BookeNeestDbContext, Configuration>
    {
    }
    
    public static class DatabaseConfig
    {
        public static void Initialize()
        {
            Database.SetInitializer(new DbInitializer());
        }
    }

}