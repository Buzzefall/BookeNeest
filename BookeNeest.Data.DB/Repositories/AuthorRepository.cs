using System.Collections.Generic;
using System.Linq;
using BookeNeest.Data.DB.Context;
using BookeNeest.Domain.Contracts.Repositories;
using BookeNeest.Domain.Models;

namespace BookeNeest.Data.DB.Repositories
{
    public class AuthorRepository : RepositoryBase<Author>, IAuthorRepository
    {
        public AuthorRepository(BookeNeestDbContext dbContext) : base(dbContext)
        {
        }

        public IList<Author> FindByName(string name)
        {
            var authors = Entities
                .Where(author => author.Name.Contains(name))
                .Take(10)
                .OrderBy( author => author.Name)
                .ToList();

            return authors;
        }
    }
}
