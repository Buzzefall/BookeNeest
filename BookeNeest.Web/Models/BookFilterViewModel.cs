using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace BookeNeest.Web.Models
{
    public class BookFilterViewModel
    {
        public string Name { get; set; }
        public string Genres { get; set; }
        public string Authors { get; set; }
        public int Rating { get; set; }
    }
}