using BookeNeest.Domain.Models;
using BookeNeest.Data.DB.Maps;

using System;
using System.Data.Entity;
using BookeNeest.Domain.Models.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace BookeNeest.Data.DB.Context
{
    public class BookeNeestDbContext : IdentityDbContext<User, Role, Guid, UserLogin, UserRole, UserClaim>
    {
        public DbSet<Book> Books { get; set; }
        public DbSet<Genre> Genres { get; set; }
        public DbSet<Author> Authors { get; set; }
        public DbSet<Review> Reviews { get; set; }
        public DbSet<Tag> Tags { get; set; }

        public static BookeNeestDbContext Create() => new BookeNeestDbContext();

        public BookeNeestDbContext() : base("BookeNeestDbConnection")
        {
            // DO NOT DO this. This prevents process of migration, migration itself creates context instance.
            // Hence, if here database is created, either initial snapshot of DB model being created or something else goes wrong... 
            //this.Database.CreateIfNotExists();
            Configuration.LazyLoadingEnabled = true;
            Configuration.AutoDetectChangesEnabled= true;
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>().ToTable("Users");
            modelBuilder.Entity<Role>().ToTable("Roles");
            modelBuilder.Entity<UserRole>().ToTable("UserRoles").HasKey(x => new { x.UserId, x.RoleId });
            modelBuilder.Entity<UserLogin>().ToTable("UserLogins").HasKey(x => new { x.UserId, x.ProviderKey});
            modelBuilder.Entity<UserClaim>().ToTable("UserClaims");

            //modelBuilder.Entity<UserLogin>().ToTable("UserLogins").HasKey(x => x.UserId);

            modelBuilder.Configurations.Add(new UserMap());
            modelBuilder.Configurations.Add(new BookMap());
            modelBuilder.Configurations.Add(new ReviewMap());
        }
        
    }
}
