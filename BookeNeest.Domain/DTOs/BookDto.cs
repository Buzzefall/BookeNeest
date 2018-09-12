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

        public BookDto(string authors, string genres)
        {
            var authors_parsed = authors.Split(new[] {',', ' ', '.'}, StringSplitOptions.RemoveEmptyEntries);
            var genres_parsed = genres.Split(new[] {',', ' ', '.'}, StringSplitOptions.RemoveEmptyEntries);

            Authors = new List<AuthorDto>();
            Genres = new List<GenreDto>();

            foreach (var genre in genres_parsed)
                Genres.Add(new GenreDto(genre));
            
            foreach (var author in authors_parsed)
                Authors.Add(new AuthorDto(author));
        }

        public override string ToString() => Name;
    }
}
