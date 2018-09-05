using System;
using System.Collections.Generic;

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


        public List<AuthorDto> Authors { get; set; }
        public List<GenreDto> Genres { get; set; }
        public List<TagDto> Tags { get; set; }

        public override string ToString() => Name;
    }
}
