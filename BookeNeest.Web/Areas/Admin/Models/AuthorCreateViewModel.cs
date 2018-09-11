using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace BookeNeest.Web.Areas.Admin.Models
{
    public class AuthorCreateViewModel
    {
        [Required]
        public string Name { get; set; }
        
        [Required]
        public string About { get; set; }
    }
}