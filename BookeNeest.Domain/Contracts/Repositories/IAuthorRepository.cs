using System.Collections.Generic;
using BookeNeest.Domain.Models;

namespace BookeNeest.Domain.Contracts.Repositories
{
    public interface IAuthorRepository : IRepositoryBase<Author>
    {
        IList<Author> FindByName(string name);
    }
}
