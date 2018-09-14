using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace BookeNeest.Web.Models
{
    public class UserViewModel
    {
        [Display(Name = "User ID")]
        public string Id { get; set; }

        [Display(Name = "E-mail")]
        public string Email { get; set; }


        [Display(Name = "Username")]
        public string UserName { get; set; }

        [Display(Name = "First Name")]
        public string FirstName { get; set; }

        [Display(Name = "Last Name")]
        public string LastName { get; set; }

        [Display(Name = "About")]
        public string About { get; set; }
    }
}