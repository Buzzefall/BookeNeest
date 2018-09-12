using System;
using System.Collections.Generic;
using System.Linq;
using BookeNeest.Data.DB.Context;
using BookeNeest.Domain.Contracts.Repositories;
using BookeNeest.Domain.Models;

namespace BookeNeest.Data.DB.Repositories
{
    public class BookRepository : RepositoryBase<Book>, IBookRepository
    {
        public BookRepository(BookeNeestDbContext dbContext) : base(dbContext)
        {

        }

        public IList<Book> FindByName(string name)
        {
            var book = Entities
                .Where(x => x.Name.Contains(name))
                .OrderBy(x => x.Name)
                .ToList();

            return book;
        }

        //public IList<Book> FindByGenre(string name)
        //{

        //}
        //public IList<Book> FindByGenre(Genre genre)
        //{
        //    var books = Entities
        //        .Where(b => b.Genres.FirstOrDefault(g => g.Id == genre.Id) != null)
        //}
    }
}