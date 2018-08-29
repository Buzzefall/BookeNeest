using BookeNest.Data.DB.Context;
using BookeNest.Domain.Contracts.Repositories;
using BookeNest.Domain.Models;

namespace BookeNest.Data.DB.Repositories
{
    public class TagRepository : RepositoryBase<Tag>, ITagRepository
    {
        public TagRepository(BookeNestDbContext dbContext) : base(dbContext)
        {

        }
    }
}
