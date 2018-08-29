using BookeNest.Data.DB.Context;
using BookeNest.Domain.Contracts.Repositories;
using BookeNest.Domain.Models;

namespace BookeNest.Data.DB.Repositories
{
    public class ReviewRepository : RepositoryBase<Review>, IReviewRepository
    {
        public ReviewRepository(BookeNestDbContext dbContext) : base(dbContext)
        {

        }
    }
}
