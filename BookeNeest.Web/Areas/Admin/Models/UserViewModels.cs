﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BookeNeest.Web.Areas.Admin.Models
{
    public class UserDetailsViewModel
    {
        [Display(Name = "Id", Order = 1)] 
        public string Id { get; set; }
        
        [Display(Name = "Username", Order = 2)] 
        public string UserName { get; set; }

        [Display(Name = "Email", Order = 3)]
        public string Email { get; set; }

    }

    public class CreateUserViewModel
    {
        [Required]
        public string UserName { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        public string Password { get; set; }

        [Required]
        public List<string> SelectedRoles { get; set; }

        //public Dictionary<string, bool> SelectedRoles { get; set; }

        public IEnumerable<SelectListItem> Roles { get; set; }
        //[Required]
        //public IEnumerable<SelectListItem> Roles { get; set; }
    }
}