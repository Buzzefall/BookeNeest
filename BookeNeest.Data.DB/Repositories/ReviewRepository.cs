using System.Collections.Generic;
using System.Linq;
using BookeNeest.Data.DB.Context;
using BookeNeest.Domain.Contracts.Repositories;
using BookeNeest.Domain.Models;

namespace BookeNeest.Data.DB.Repositories
{
    public class ReviewRepository : RepositoryBase<Review>, IReviewRepository
    {
        public ReviewRepository(BookeNeestDbContext dbContext) : base(dbContext)
        {

        }

        public IList<Review> FindByName(string name)
        {
            var reviews = Entities
                .Where(x => x.Title.Contains(name))
                .OrderBy(x => x.Title)
                .ToList();

            return reviews;
        }
    }
}
