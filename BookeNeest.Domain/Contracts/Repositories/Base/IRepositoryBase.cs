using System;
using System.Linq;

namespace BookeNeest.Domain.Contracts.Repositories
{
    public interface IRepositoryBase<TEntity>
    {
        IQueryable<TEntity> Entities { get; }
        
        TEntity FindById(Guid guid);
        void Add(TEntity author);
        void Remove(TEntity author);
    }
}
