using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
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

            if (filter.MaxRating > filter.MinRating)
            {
                books = books.Where(book => book.Rating <= filter.MaxRating);
            }

            if (filter.Name != null)
            {
                books = books.Where(book => book.Name.Contains(filter.Name));
            }

            if (filter.Authors != null)
            {
                var regex = new Regex(@"[a-zA-Zа-яА-Я]*( *[a-zA-Zа-яА-Я]*)*");
                var matches = regex.Matches(filter.Authors);
                var authorNames = matches.Cast<Match>().Select(m => m.Value).ToArray();
                
                books = books.Where(book => book.Authors.All(author => authorNames.Contains(author.Name)));
                // var authorNames = filter.Authors.Split(new[] {',', '.'}, StringSplitOptions.RemoveEmptyEntries);
                // var authors = unitOfWork.AuthorRepository.Entities.Where(x => authorNames.Contains(x.Name));
            }

            if (filter.Genres != null)
            {
                var genreNames = filter.Genres.Split(new[] {" , ", " ,", " .", "." }, StringSplitOptions.RemoveEmptyEntries);
                var a = default(Author);
                //var genres = unitOfWork.GenreRepository.Entities.Where(x => genreNames.Contains(x.Name));

                foreach (var genre in genreNames)
                {
                    books = books.Where(book => book.Genres.FirstOrDefault(x => x.Name == genre) != null);
                }
            }

            var bookDtos = Mapper.Map<IList<BookDto>>(books);

            return bookDtos;
        }
    }
}