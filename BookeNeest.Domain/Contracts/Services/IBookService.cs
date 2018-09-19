using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BookeNeest.Domain.DTOs;
using BookeNeest.Domain.Models;

namespace BookeNeest.Domain.Contracts.Services
{
    public interface IBookService : IServiceBase<BookDto>
    {
        IList<BookDto> GetBooksRecent(int amount);

        IList<BookDto> GetBooksFiltered(int amount);
    }
}
