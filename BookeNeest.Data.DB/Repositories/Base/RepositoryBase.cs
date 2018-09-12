using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using BookeNeest.Data.DB.Context;
using BookeNeest.Domain.Contracts.Repositories;
using BookeNeest.Domain.Models;

namespace BookeNeest.Data.DB.Repositories
{
    public abstract class RepositoryBase<TEntity> : IRepositoryBase<TEntity>
        where TEntity : EntityBase<Guid>
    {
        private readonly BookeNeestDbContext _dbContext;

        private IDbSet<TEntity> _dbSet => _dbContext.Set<TEntity>();
        public IQueryable<TEntity> Entities => _dbSet;

        public RepositoryBase(BookeNeestDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public void Add(TEntity entity)
        {
            if (entity != null)
            {
                _dbSet.Add(entity);
            }
        }

        public void Remove(TEntity entity)
        {
            if (entity != null)
            {
                _dbSet.Remove(entity);
            }
        }

        public TEntity FindById(Guid id)
        {
            return _dbSet.Find(id);
        }

        public  IList<TEntity> GetRecent(int amount)
        {
            var requested = Entities
                .Take(amount)
                .ToList();

            return requested;
        }
    }
}