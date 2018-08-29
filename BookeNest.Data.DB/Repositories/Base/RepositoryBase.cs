using System;
using System.Data.Entity;
using System.Linq;
using BookeNest.Data.DB.Context;
using BookeNest.Domain.Contracts.Repositories;
using BookeNest.Domain.Models;

namespace BookeNest.Data.DB.Repositories
{
    public class RepositoryBase<TEntity> : IRepositoryBase<TEntity>
        where TEntity : EntityBase<Guid>
    {
        private readonly BookeNestDbContext _DbContext;

        private IDbSet<TEntity> _DbSet => _DbContext.Set<TEntity>();
        public IQueryable<TEntity> Entities => _DbSet;

        public RepositoryBase(BookeNestDbContext dbContext)
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