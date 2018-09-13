﻿using System;
using System.Collections.Generic;
using System.Linq;

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

            Authors = authors_parsed.Select(a => new AuthorDto(a)).ToList();
            Genres = genres_parsed.Select(g => new GenreDto(g)).ToList();
        }

        public override string ToString() => Name;
    }
}
