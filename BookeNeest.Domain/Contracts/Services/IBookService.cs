using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BookeNeest.Domain.DTOs;
using BookeNeest.Domain.Models;

namespace BookeNeest.Domain.Contracts.Services
{
    public interface IBookService
    {
        BookDto FindByName(string name);
        BookDto FindById(Guid id);
        IList<BookDto> GetRecentBooks(int amount);
        void AddBook(BookDto bookDto);
    }
}
