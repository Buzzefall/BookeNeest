using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using BookeNeest.Domain.Contracts;
using BookeNeest.Domain.Contracts.Services;
using BookeNeest.Domain.DTOs;
using BookeNeest.Domain.Models;
using BookeNeest.Data.DB;
using Unity.Attributes;

namespace BookeNeest.LogicLayer.Services
{
    public class BookService : ServiceBase, IBookService
    {
        [InjectionConstructor]
        public BookService(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
        }

        public Guid AddNew(BookDto bookDto)
        {
            var book = Mapper.Map<Book>(bookDto);

            book.Id = Guid.NewGuid();

            unitOfWork.BookRepository.Add(book);
            unitOfWork.CommitAsync();

            return book.Id;
        }

        public BookDto FindById(Guid id)
        {
            var book = unitOfWork.BookRepository.FindById(id);

            return Mapper.Map<BookDto>(book);
        }

        public IList<BookDto> FindByName(string name)
        {
            var book = unitOfWork.BookRepository.FindByName(name);

            return Mapper.Map<IList<BookDto>>(book);
        }

        public IList<BookDto> GetRecentBooks(int amount)
        {
            var books = unitOfWork.BookRepository.GetRecent(amount);

            return Mapper.Map<IList<BookDto>>(books);
        }
    }
}