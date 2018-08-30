using System;
using System.Data.Entity;
using System.Linq;
using BookeNeest.Domain;
using BookeNeest.Data.DB.Context;
using BookeNeest.Data.DB.Repositories;
using BookeNeest.Domain.Contracts.Repositories;
using Unity.Attributes;

namespace BookeNeest.Data.DB
{
    public class UnitOfWork : IUnitOfWork, IDisposable
    {
        private readonly BookeNeestDbContext _dbContext;

        public IBookRepository BookRepository { get; }
        public IGenreRepository GenreRepository { get; }
        public IAuthorRepository AuthorRepository { get; }
        public IReviewRepository ReviewRepository { get; }
        public ITagRepository TagRepository { get; }

        //public IBookRepository BookRepository => _bookRepository ?? (_bookRepository = new BookRepository(_dbContext));

        //public UnitOfWork(BookeNeestDbContext dbContext)
        //{
        //    _dbContext = dbContext;
        //}

        [InjectionConstructor]
        public UnitOfWork(
            IBookRepository bookRepository,
            IGenreRepository genreRepository,
            IAuthorRepository authorRepository,
            IReviewRepository reviewRepository,
            ITagRepository tagRepository)
        {
            _dbContext = BookeNeestDbContext.Create();

            BookRepository = bookRepository;
            GenreRepository = genreRepository;
            AuthorRepository = authorRepository;
            ReviewRepository = reviewRepository;
            TagRepository = tagRepository;
        }

        public void Commit()
        {
            _dbContext.SaveChanges();
        }

        public void Discard()
        {
            foreach (var entry in _dbContext.ChangeTracker.Entries().Where(e => e.State != EntityState.Unchanged))
            {
                switch (entry.State)
                {
                    case EntityState.Added:
                        entry.State = EntityState.Detached;
                        break;
                    case EntityState.Modified:
                    case EntityState.Deleted:
                        entry.Reload();
                        break;
                }
            }
        }

        public void Dispose()
        {
            _dbContext.Dispose();
        }
    }
}