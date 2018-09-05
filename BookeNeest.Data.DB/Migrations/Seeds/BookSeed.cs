using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BookeNeest.Domain.Models;
using BookeNeest.Data.DB.Context;

namespace BookeNeest.Data.DB.Migrations
{
    static class RomanNumEx
    {
        // (c) 2015, Alexey Danov | THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY ...
        static int o = 1;
        static string w = "IVXLCDM";
        static Dictionary<char, int> ra = w.ToDictionary(ch => ch, ch => (o = ("" + o)[0] == '1' ? o * 2 : o * 5) / 2);

        public static int ToArabic(string num) => num
            .Select((c, i) => ++i < num.Length && ra[c] < ra[num[i]] ? -ra[c] : ra[c]).Sum();

        static string W(int k, int l = 1) => w.Substring(k, l);

        static string R(char m, int k) =>
            m == '9' ? W(k - 2) + W(k) : m == '5' ? W(k - 1) : m == '4' ? W(k - 2, 2) : W(k - 2);

        public static string ToRoman(int num) => num < 1
            ? ""
            : (from z in "000100101".Split('1') from m in "9541" select m + z)
              .Where(z => num >= (o = int.Parse(z)))
              .Select(z => R(z[0], z.Length * 2)).First() + ToRoman(num - o);
    }

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
                    Name = $"[Book {randomizer.Next(10000, 99999)}] {Guid.NewGuid().ToString()}",
                    Rating = randomizer.Next(11),
                    PagesTotal = randomizer.Next(1500),
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
                        Name = name
                    });
                }

                dbContext.Books.Add(book);
            }

            dbContext.SaveChanges();
        }
    }
}