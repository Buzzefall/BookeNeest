using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace BookeNeest.Web.Models
{
    public class AddBookViewModel
    {
        [DataType(DataType.Text)]
        [Display(Name = "ISBN", Order = 1)]
        public string ISBN { get; set; }

        [Required]
        [DataType(DataType.Text)]
        [Display(Name = "Name", Order = 2)]
        public string Name { get; set; }

        [DataType(DataType.Text)]
        [Display(Name = "PublicationDate", Order = 3)]
        public string PublicationDate { get; set; }

        [DataType(DataType.Custom)]
        [Display(Name = "PagesTotal", Order = 4)]
        public int? PagesTotal { get; set; }

        [DataType(DataType.Custom)]
        [Display(Name = "Rating", Order = 5)]
        public int? Rating { get; set; }

        [DataType(DataType.Text)]
        [Display(Name = "Authors", Order = 6)]
        public string Authors { get; set; }

        [DataType(DataType.Text)]
        [Display(Name = "Genres", Order = 7)]
        public string Genres { get; set; }
        
        [DataType(DataType.MultilineText)]
        [Display(Name = "Description", Order = 8)]
        public string Description { get; set; }

        [DataType(DataType.MultilineText)]
        [Display(Name = "Description", Order = 9)]
        public string Tags { get; set; }
    }
}