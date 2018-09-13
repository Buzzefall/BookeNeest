using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BookeNeest.Domain.DTOs;

namespace BookeNeest.Web.Models
{
    public class BookViewModel
    {
        public string Id { get; set; }
        public string ISBN { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string PublicationDate { get; set; }
        public int? PagesTotal { get; set; }
        public int? Rating { get; set; }

        public IList<AuthorViewModel> Authors { get; set; }
        public IList<GenreViewModel> Genres { get; set; }
        public IList<TagViewModel> Tags { get; set; }
    }
}