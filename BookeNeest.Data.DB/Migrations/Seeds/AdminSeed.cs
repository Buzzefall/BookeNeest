using System;
using System.Linq;
using System.Text;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using BookeNeest.Data.DB.Context;
using BookeNeest.Domain.Identity;

namespace BookeNeest.Data.DB.Migrations
{
    internal sealed partial class Configuration
    {
        private void SeedRolesAndUsers(BookeNeestDbContext dbContext)
        {
            var userStore = new UserStore<User, Role, Guid, UserLogin, UserRole, UserClaim>(dbContext);
            var roleStore = new RoleStore<Role, Guid, UserRole>(dbContext);

            var userManager = new UserManager<User, Guid>(userStore);
            var roleManager = new RoleManager<Role, Guid>(roleStore);

            // Seeding Roles:

            if (!roleManager.RoleExists("Admin"))
                roleManager.Create(new Role() {Id = Guid.NewGuid(), Name = "Admin"});

            if (!roleManager.RoleExists("Critic"))
                roleManager.Create(new Role() {Id = Guid.NewGuid(), Name = "Critic"});

            if (!roleManager.RoleExists("Guest"))
                roleManager.Create(new Role() {Id = Guid.NewGuid(), Name = "Guest"});

            var adminRole = roleManager.FindByName("Admin");

            // Seeding admin account: 
            var users = userManager.Users;
            if (users.Any(user => user.Roles.Any(role => role.RoleId == adminRole.Id)) == false)
            {
                var admin = userManager.FindByName("Xander");

                if (admin != null)
                {
                    userManager.Delete(admin);
                }

                admin = new User()
                {
                    Id = Guid.NewGuid(),
                    UserName = "Xander",
                    FirstName = "A",
                    LastName = "D",
                    Email = "master.chief.cab@gmail.com",
                    EmailConfirmed = true,
                    About = "The almighty governor of this site"
                };
                var password = "Admin1_";


                var result = userManager.Create(admin, password);

                if (result.Succeeded)
                {
                    userManager.AddToRoles(admin.Id, "Admin", "Critic");
                }
                else
                {
                    StringBuilder bldr = new StringBuilder();
                    bldr.Append("Errors:");
                    foreach (var err in result.Errors)
                    {
                        bldr.Append("\n" + err);
                    }

                    throw new Exception("Failed to create BookeNeest administrator!\n" + bldr);
                }

                dbContext.SaveChanges();
            }

            //store.Dispose();
            //manager.Dispose();
        }
    }
}