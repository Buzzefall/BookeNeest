using System;
using System.Data.Entity;
using System.Linq;

using BookeNest.Domain;
using BookeNest.Data.DB.Context;
using BookeNest.Data.DB.Repositories;
using BookeNest.Domain.Contracts.Repositories;

namespace BookeNest.Data.DB
{
    public class UnitOfWork : IUnitOfWork, IDisposable
    {
        private readonly BookeNestDbContext _dbContext;

        private BookRepository _bookRepository;
        private GenreRepository _genreRepository;
        private AuthorRepository _authorRepository;
        private ReviewRepository _reviewRepository;
        private TagRepository _tagRepository;

        public IBookRepository BookRepository => _bookRepository ?? (_bookRepository = new BookRepository(_dbContext));
        public IGenreRepository GenreRepository => _genreRepository ?? (_genreRepository = new GenreRepository(_dbContext));
        public IAuthorRepository AuthorRepository => _authorRepository ?? (_authorRepository = new AuthorRepository(_dbContext));
        public IReviewRepository ReviewRepository => _reviewRepository ?? (_reviewRepository = new ReviewRepository(_dbContext));
        public ITagRepository TagRepository => _tagRepository ?? (_tagRepository = new TagRepository(_dbContext));

        public UnitOfWork()
        {
            _dbContext = BookeNestDbContext.Create();
        }

        public UnitOfWork(BookeNestDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public void Commit()
        {
            _dbContext.SaveChanges();
        }

        public void Discard()
        {
            foreach (var entry in _dbContext.ChangeTracker.Entries().
                        Where(e => e.State != EntityState.Unchanged))
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
