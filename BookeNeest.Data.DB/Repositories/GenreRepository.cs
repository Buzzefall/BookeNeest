using System.Collections.Generic;
using System.Linq;
using BookeNeest.Data.DB.Context;
using BookeNeest.Domain.Contracts.Repositories;
using BookeNeest.Domain.Models;

namespace BookeNeest.Data.DB.Repositories
{
    public class GenreRepository : RepositoryBase<Genre>, IGenreRepository
    {
        public GenreRepository(BookeNeestDbContext dbContext) : base(dbContext)
        {
        }

        public IList<Genre> FindByName(string name)
        {
            var genres = Entities
                .Where(g => g.Name.Contains(name))
                .OrderBy(g => g.Name)
                .ToList();

            return genres;
        }
    }
}