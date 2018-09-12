using System.Collections.Generic;
using BookeNeest.Domain.DTOs;

namespace BookeNeest.Domain.Contracts.Services

{
    public interface IAuthorService : IServiceBase<AuthorDto>
    {
        IList<AuthorDto> TakeAuthorsOrdered(int amount);
    }
}
