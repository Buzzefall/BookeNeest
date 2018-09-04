using System;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using BookeNeest.Data.DB;
using BookeNeest.Domain;
using BookeNeest.Domain.Contracts.Services;
using BookeNeest.Domain.DTOs;
using BookeNeest.Domain.Models;
using Unity.Attributes;

namespace BookeNeest.LogicLayer.Services
{
    public class BookService : ServiceInitializer, IBookService
    {
        private readonly IUnitOfWork unitOfWork;

        [InjectionConstructor]
        public BookService()
        {
            this.unitOfWork = new UnitOfWork();
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
            #region AddBooksForTest

            var available = unitOfWork.BookRepository.Entities.Count();
            if (available < amount)
            {
                var randomizer = new Random();
                for (int i = 0; i < amount; i++)
                {
                    Book book = new Book
                    {
                        Id = Guid.NewGuid(),
                        ISBN = Guid.NewGuid().ToString(),
                        Name = $"[Book {randomizer.Next()}] " + Guid.NewGuid().ToString(),
                        Rating = randomizer.Next(10) + 1
                    };
                    unitOfWork.BookRepository.Add(book);
                }

                unitOfWork.Commit();
            }

            #endregion

            var books = unitOfWork.BookRepository.Entities.OrderBy(x => x.Id).Take(amount).ToList();

            return Mapper.Map<IList<BookDto>>(books);
        }
    }
}