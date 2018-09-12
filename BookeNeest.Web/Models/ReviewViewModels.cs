using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace BookeNeest.Web.Models
{
    public class ReviewViewModel
    {
        [Display(Name = "User ID")]
        public Guid UserId { get; set; }

        [Display(Name = "Book ID")]
        public Guid BookId { get; set; }
        
        [Display(Name = "Text")]
        public string Text { get; set; }

        [Display(Name = "Rating")]
        public int? Rating { get; set; }
    }
}