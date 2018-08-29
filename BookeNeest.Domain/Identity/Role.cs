using System;
using Microsoft.AspNet.Identity.EntityFramework;

namespace BookeNeest.Domain.Identity
{
    public class Role : IdentityRole<Guid, UserRole>
    {
        
    }
}
