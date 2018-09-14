using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace BookeNeest.Web.Models
{
    public class ReviewViewModel
    {
        [Display(Name = "Id")]
        public string Id { get; set; }

        [Display(Name = "Text")]
        public string Text { get; set; }

        [Display(Name = "Title")]
        public string Title { get; set; }

        [Display(Name = "Rating")]
        public int? Rating { get; set; }
        
        [Display(Name = "User ID")]
        public string UserId { get; set; }

        [Display(Name = "Book ID")]
        public string BookId { get; set; }

        public string BookName { get; set; }
    }
}