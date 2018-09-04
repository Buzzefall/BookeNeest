using System;
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

        public Book FindByName(string name)
        {
            var book = Entities.FirstOrDefault(x => x.Name == name);
            return book;
        }
    }
}