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
using BookeNeest.LogicLayer.Services.Base;
using Unity.Attributes;

namespace BookeNeest.LogicLayer.Services
{
    public class BookService : ServiceBase<BookDto>, IBookService
    {
        private readonly IUnitOfWork unitOfWork;

        [InjectionConstructor]
        public BookService(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
        }

        public void AddNew(BookDto bookDto)
        {
            var book = Mapper.Map<Book>(bookDto);

            unitOfWork.BookRepository.Add(book);
            unitOfWork.CommitAsync();
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
            var books = unitOfWork.BookRepository.GetBooksOrdered(amount);

            return Mapper.Map<IList<BookDto>>(books);
        }
    }
}