using System.Collections.Generic;
using BookeNeest.Domain.DTOs;

namespace BookeNeest.Domain.Contracts.Services

{
    public interface IAuthorService : IServiceBase<AuthorDto>
    {
        List<AuthorDto> GetAuthorsOrdered(int amount);
    }
}
