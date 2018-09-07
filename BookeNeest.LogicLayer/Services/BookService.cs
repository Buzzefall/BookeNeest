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
    public class BookService : IBookService
    {
        private readonly IUnitOfWork unitOfWork;

        [InjectionConstructor]
        public BookService()
        {
            this.unitOfWork = new UnitOfWork();
        }

        public void AddBook(BookDto bookDto)
        {
            var book = Mapper.Map<Book>(bookDto);
            
            unitOfWork.BookRepository.Add(book);
            unitOfWork.CommitAsync();
        }

        public BookDto FindByName(string name)
        {
            var book = unitOfWork.BookRepository.FindByName(name);
            
            // TODO: Automapper
            return Mapper.Map<BookDto>(book);
        }

        public BookDto FindById(Guid id)
        {
            var book = unitOfWork.BookRepository.FindById(id);

            return Mapper.Map<BookDto>(book);
        }

        public IList<BookDto> GetRecentBooks(int amount)
        {
            var books = unitOfWork.BookRepository.Entities.OrderBy(x => x.Id).Take(amount).ToList();
            return Mapper.Map<IList<BookDto>>(books);
        }
    }
}