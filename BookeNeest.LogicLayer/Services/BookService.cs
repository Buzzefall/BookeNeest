using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using BookeNeest.Domain.Contracts;
using BookeNeest.Domain.Contracts.Services;
using BookeNeest.Domain.DTOs;
using BookeNeest.Domain.Models;
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

        public IList<BookDto> GetBooksRecent(int amount)
        {
            var books = unitOfWork.BookRepository.GetRecent(amount);

            var bookDtos = Mapper.Map<IList<BookDto>>(books);

            return bookDtos;
        }

        public IList<BookDto> GetBooksFiltered(BookFilter filter)
        {
            if (filter == null)
            {
                throw new Exception("BookFilter is null");
            }

            var books = unitOfWork.BookRepository.Entities
                .Where(book => book.Rating >= filter.MinRating);
            
            books = books
                .Where(book => book.Rating <= filter.MaxRating);

            if (filter.Name != null)
            {
                books = books.Where(book => book.Name.Contains(filter.Name));
            }

            if (filter.Authors != null)
            {
                var authorNames = filter.Authors.Split(new[] {',', '.'}, StringSplitOptions.RemoveEmptyEntries);

                var authors = unitOfWork.AuthorRepository.Entities.Where(x => authorNames.Contains(x.Name));

                foreach (var author in authors)
                {
                    books = books.Where(book => book.Authors.Contains(author));
                }
            }

            if (filter.Genres != null)
            {
                var genreNames = filter.Genres.Split(new[] {',', '.'}, StringSplitOptions.RemoveEmptyEntries);

                var genres = unitOfWork.GenreRepository.Entities.Where(x => genreNames.Contains(x.Name));

                foreach (var genre in genres)
                {
                    books = books.Where(book => book.Genres.Contains(genre));
                }
            }

            var bookDtos = Mapper.Map<IList<BookDto>>(books);

            return bookDtos;
        }
    }
}