using System;
using System.Collections.Generic;
using System.Linq;

namespace BookeNeest.Domain.DTOs
{
    public class BookDto : EntityBaseDto<Guid>
    {
        public string ISBN { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime PublicationDate { get; set; }
        public int PagesTotal { get; set; }
        public int Rating { get; set; }


        public IList<AuthorDto> Authors { get; set; }
        public IList<GenreDto> Genres { get; set; }
        public IList<TagDto> Tags { get; set; }

        public override string ToString() => Name;
    }
}
