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
            unitOfWork.Commit();

            return book.Id;
        }

        public async Task<Guid> AddNewAsync(BookDto bookDto)
        {
            var book = Mapper.Map<Book>(bookDto);

            book.Id = Guid.NewGuid();

            unitOfWork.BookRepository.Add(book);
            await unitOfWork.CommitAsync();

            return book.Id;
        }

        public BookDto FindById(Guid id)
        {
            var book = unitOfWork.BookRepository.FindById(id);
            var bookDto = Mapper.Map<BookDto>(book);

            return bookDto;
        }

        public IList<BookDto> FindByName(string name)
        {
            var books = unitOfWork.BookRepository.FindByName(name);
            var bookDtos = Mapper.Map<IList<BookDto>>(books);

            return bookDtos;
        }

        public IList<BookDto> GetRecentBooks(int amount)
        {
            var books = unitOfWork.BookRepository.GetRecent(amount);
            var bookDtos = Mapper.Map<IList<BookDto>>(books);

            return bookDtos;
        }
    }
}