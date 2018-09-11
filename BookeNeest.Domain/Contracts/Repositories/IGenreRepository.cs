using System.Collections.Generic;
using BookeNeest.Domain.Models;

namespace BookeNeest.Domain.Contracts.Repositories
{
    public interface IGenreRepository : IRepositoryBase<Genre>
    {
        IList<Genre> FindByName(string name);
    }
}
