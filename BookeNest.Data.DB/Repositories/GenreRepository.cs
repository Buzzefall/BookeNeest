using BookeNest.Data.DB.Context;
using BookeNest.Domain.Contracts.Repositories;
using BookeNest.Domain.Models;

namespace BookeNest.Data.DB.Repositories
{
    public class GenreRepository : RepositoryBase<Genre>, IGenreRepository
    {
        public GenreRepository(BookeNestDbContext dbContext) : base(dbContext)
        {

        }
    }
}
