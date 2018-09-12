using System;
using System.Collections.Generic;
using System.Linq;

namespace BookeNeest.Domain.Contracts.Repositories
{
    public interface IRepositoryBase<TEntity>
    {
        IQueryable<TEntity> Entities { get; }
        
        TEntity FindById(Guid guid);
        IList<TEntity> GetRecent(int amount);
        void Add(TEntity author);
        void Remove(TEntity author);
    }
}
