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
            var unitOfWork = new UnitOfWork(dbContext);

            var available = unitOfWork.BookRepository.Entities.Count();

            if (available >= amount) return;

            var emperors = new [] {
                "Charles",
                "Vicious",
                "Tritone",
                "Tristan",
                "Falmar",
                "Kronos",
                "Dionis Pompey",
                "Lucius Aurelius",
                "Emperus Spardos",
                "Cortus Emerus",
                "Prester Bassianus",
                "Lotar Dagobert",
                "Dio Eraclea"
            };

            var randomizer = new Random((int) DateTime.Now.Ticks);

            for (int i = 0; i < amount; i++)
            {
                Book book = new Book
                {
                    Id = Guid.NewGuid(),
                    ISBN = Guid.NewGuid().ToString(),
                    Name = $"[Book {RomanNumEx.ToRoman(randomizer.Next(10, 99))}-{RomanNumEx.ToRoman(randomizer.Next(100, 999))}]",
                    Rating = randomizer.Next(10) + 1,
                    PagesTotal = randomizer.Next(1500),
                    PublicationDate = DateTime.Today,
                    Description = "This book is amazing!!! Bla bla bla-a-a...",
                    Genres = new List<Genre>()
                    {
                        new Genre
                        {
                            Id = Guid.NewGuid(),
                            Name = $"Weirdo Genro",
                            Description = "Something re-e-ally weirdo!",
                        },

                        new Genre
                        {
                            Id = Guid.NewGuid(),
                            Name = $"Mainstream Genre",
                            Description = "Don't you know???",
                        },
                    },

                    Authors = new List<Author>()
                };

                for (int j = 0; j < book.Rating; j++)
                {

                    var name = emperors[j % emperors.Length];

                    if (!name.Contains(" "))
                    {
                        name += $" {RomanNumEx.ToRoman(randomizer.Next(10, 125))}";
                    }

                    var existing = dbContext.Authors.FirstOrDefault(a => a.Name == name);

                    book.Authors.Add(existing ?? new Author()
                    {
                        Id = Guid.NewGuid(), 
                        Name = name,
                        About = "Almighty king of... what country?",
                        BirthDate = DateTime.Today.Subtract(TimeSpan.FromDays(13337)), //else SQL-db won't accept null value
                        DeathDate = DateTime.Today, //else SQL-db won't accept null value
                    });
                }

                unitOfWork.BookRepository.Add(book);
            }

            dbContext.SaveChanges();
        }
    }
}