using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BookeNeest.Domain.DTOs;

namespace BookeNeest.Domain.Contracts.Services
{
    public interface IReviewService : IServiceBase<ReviewDto>
    {
        IList<ReviewDto> GetRecentReviews(int amount);
    }
}
