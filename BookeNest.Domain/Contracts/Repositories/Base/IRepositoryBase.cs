using System;
using System.Linq;

namespace BookeNest.Domain.Contracts.Repositories
{
    public interface IRepositoryBase<TEntity>
    {
        IQueryable<TEntity> Entities { get; }
        
        TEntity FindById(Guid guid);
        void Add(TEntity author);
        void Remove(TEntity author);
    }
    //public interface IRepository<TEntity, TKey>
    //{
    //    IQueryable<TEntity> Entities { get; }
    //    TEntity FindById(TKey id);
        
    //    void Add(TEntity author);
    //    void Remove(TEntity author);
    //}
}
