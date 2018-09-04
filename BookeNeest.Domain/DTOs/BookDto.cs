using System;
using System.Collections.Generic;

using BookeNeest.Domain.DTOs.Base;

namespace BookeNeest.Domain.DTOs
{
    public class BookDto : EntityBaseDto<Guid>
    {
        public string ISBN { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string PublicationDate { get; set; }
        public int? PagesTotal { get; set; }
        public int? Rating { get; set; }


        public List<string> Authors { get; set; }
        public List<string> Genres { get; set; }
        public List<string> Tags { get; set; }
    }
}
