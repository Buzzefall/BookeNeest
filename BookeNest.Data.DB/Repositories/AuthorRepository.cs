using BookeNest.Data.DB.Context;
using BookeNest.Domain.Contracts.Repositories;
using BookeNest.Domain.Models;

namespace BookeNest.Data.DB.Repositories
{
    public class AuthorRepository : RepositoryBase<Author>, IAuthorRepository
    {
        public AuthorRepository(BookeNestDbContext dbContext) : base(dbContext)
        {

        }
    }
}
