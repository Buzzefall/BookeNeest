using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BookeNeest.Domain.Models;
using BookeNeest.Data.DB.Context;
using BookeNeest.Data.DB.Helpers;

namespace BookeNeest.Data.DB.Migrations
{
    internal sealed partial class Configuration
    {
        private void SeedBooks(BookeNeestDbContext dbContext, int amount)
        {
            var available = dbContext.Books.Count();

            if (available >= amount) return;

            var randomizer = new Random((int) DateTime.Now.Ticks);

            for (int i = 0; i < amount; i++)
            {
                Book book = new Book
                {
                    Id = Guid.NewGuid(),
                    ISBN = Guid.NewGuid().ToString(),
                    Name = $"[Book {RomanNumEx.ToRoman(randomizer.Next(10, 99))}-{RomanNumEx.ToRoman(randomizer.Next(100, 999))}]",
                    Rating = randomizer.Next(11),
                    PagesTotal = randomizer.Next(1500),
                    PublicationDate = DateTime.Today.ToLongDateString(),
                    Description = "This book is amazing!!! Bla bla bla-a-a...",
                    Genres = new List<Genre>()
                    {
                        new Genre
                        {
                            Id = Guid.NewGuid(),
                            Name = $"Weirdo Genro №{randomizer.Next(10000, 99999)}",
                            Description = "Something re-e-ally weirdo!"
                        },
                        new Genre
                        {
                            Id = Guid.NewGuid(),
                            Name = $"Mainstream Genre №{randomizer.Next(10000, 99999)}",
                            Description = "You dare to ask for it?"
                        },
                    },

                    Authors = new List<Author>()
                };

                for (int j = 0; j < book.Rating; j++)
                {
                    var name = $"Charles {RomanNumEx.ToRoman(randomizer.Next(10, 99))}";
                    var existing = dbContext.Authors.FirstOrDefault(a => a.Name == name);
                    book.Authors.Add(existing ?? new Author()
                    {
                        Id = Guid.NewGuid(),
                        Name = name,
                        About = "Almighty king of... what country?"
                    });
                }

                dbContext.Books.Add(book);
            }

            dbContext.SaveChanges();
        }
    }
}