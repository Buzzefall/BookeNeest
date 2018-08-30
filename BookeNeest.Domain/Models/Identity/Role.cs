using System;
using Microsoft.AspNet.Identity.EntityFramework;

namespace BookeNeest.Domain.Models.Identity
{
    public class Role : IdentityRole<Guid, UserRole>
    {
        
    }
}
