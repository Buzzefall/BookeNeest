using System.Collections.Generic;
using BookeNeest.Domain.Models;

namespace BookeNeest.Domain.Contracts.Repositories
{
    public interface IReviewRepository : IRepositoryBase<Review>
    {
        IList<Review> FindByName(string name);
    }
}
