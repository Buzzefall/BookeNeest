using BookeNest.Domain.Models;

using System;
using System.Threading.Tasks;
using System.Collections.Generic;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System.Security.Claims;

namespace BookeNest.Domain.Identity
{
    public class User : IdentityUser<Guid, UserLogin, UserRole, UserClaim>
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string About { get; set; }

        public virtual ICollection<Book> Books { get; set; }
        public virtual ICollection<Review> Reviews { get; set; }



        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<User, Guid> manager)
        {
            // Note the authenticationType must match the one defined in CookieAuthenticationOptions.AuthenticationType
            var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);
            // Add custom user claims here
            return userIdentity;
        }
    }
}
