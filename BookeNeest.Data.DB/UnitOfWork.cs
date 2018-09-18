using System;
using System.Data.Entity;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using Unity.Attributes;

using BookeNeest.Domain.Contracts;
using BookeNeest.Domain.Contracts.Repositories;
using BookeNeest.Data.DB.Context;
using BookeNeest.Data.DB.Repositories;

namespace BookeNeest.Data.DB
{
    public class UnitOfWork : IUnitOfWork, IDisposable
    {
        private readonly BookeNeestDbContext _dbContext;

        private IBookRepository _bookRepository;
        private IGenreRepository _genreRepository;
        private IAuthorRepository _authorRepository;
        private IReviewRepository _reviewRepository;
        private ITagRepository _tagRepository;

        public IBookRepository BookRepository => _bookRepository ?? (_bookRepository = new BookRepository(_dbContext));
        public IGenreRepository GenreRepository => _genreRepository ?? (_genreRepository= new GenreRepository(_dbContext));
        public IAuthorRepository AuthorRepository => _authorRepository ?? (_authorRepository = new AuthorRepository(_dbContext));
        public IReviewRepository ReviewRepository => _reviewRepository ?? (_reviewRepository = new ReviewRepository(_dbContext));
        public ITagRepository TagRepository => _tagRepository ?? (_tagRepository = new TagRepository(_dbContext));

        public UnitOfWork()
        {
            _dbContext = new BookeNeestDbContext();
        }

        //public IRepository GetRepository<IRepository>()
        //{
        //    var propertyInfo = GetType()
        //        .GetProperties(BindingFlags.Public)
        //        .FirstOrDefault(p => p.PropertyType == typeof(IRepository));

        //    return (IRepository) propertyInfo.GetValue(this);
        //}


        public void Commit()
        {
            _dbContext.SaveChanges();
        }

        public async Task CommitAsync()
        {
            await _dbContext.SaveChangesAsync();
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