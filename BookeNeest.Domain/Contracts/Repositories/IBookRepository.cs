using System.Collections.Generic;
using BookeNeest.Domain.Models;

namespace BookeNeest.Domain.Contracts.Repositories
{
    public interface IBookRepository : IRepositoryBase<Book>
    {
        IList<Book> FindByName(string name);

        //IList<Book> FindByGenre(string name);
        //IList<Book> FindByGenre(Genre genre);

        IList<Book> GetBooksOrdered(int amount);
    }
}
