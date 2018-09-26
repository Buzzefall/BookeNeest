using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace BookeNeest.Web.Models
{
    public class AuthorViewModel
    {
        [Display(Name = "Author ID")]
        public string Id { get; set; }

        [Display(Name = "Name")]

        public string Name { get; set; }

        [Display(Name = "About")]
        public string About { get; set; }

        [Display(Name = "Birth Date")]
        [DataType(DataType.Date)]
        public DateTime BirthDate { get; set; }

        [Display(Name = "Death Date")]
        [DataType(DataType.Date)]
        public DateTime DeathDate { get; set; }

    }
}