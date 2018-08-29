using System;
using System.Data.Entity;
using System.Linq;
using BookeNeest.Data.DB.Context;
using BookeNeest.Domain.Contracts.Repositories;
using BookeNeest.Domain.Models;

namespace BookeNeest.Data.DB.Repositories
{
    public class RepositoryBase<TEntity> : IRepositoryBase<TEntity>
        where TEntity : EntityBase<Guid>
    {
        private readonly BookeNeestDbContext _DbContext;

        private IDbSet<TEntity> _DbSet => _DbContext.Set<TEntity>();
        public IQueryable<TEntity> Entities => _DbSet;

        public RepositoryBase(BookeNeestDbContext dbContext)
        {
            _DbContext = dbContext;
        }

        public void Add(TEntity entity)
        {
            if (entity != null)
            {
                _DbSet.Add(entity);
            }
        }

        public void Remove(TEntity entity)
        {
            if (entity != null)
            {
                _DbSet.Remove(entity);
            }
        }

        public TEntity FindById(Guid id)
        {
            return _DbSet.Find(id);
        }
    }
}