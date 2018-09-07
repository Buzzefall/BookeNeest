using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BookeNeest.Web.Models
{
    public class AddBookViewModel
    {
        public string Id { get; set; }
        public string ISBN { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string PublicationDate { get; set; }
        public int? PagesTotal { get; set; }
        public int? Rating { get; set; }


        public string Authors { get; set; }
        public string Genres { get; set; }
        public string Tags { get; set; }
    }
}