using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using test.Domain.Entities;

namespace test.Domain.Contracts
{
    public interface IBaseRepository<TEntity>:IDisposable where TEntity:EntidadBase
    {
        Task<IEnumerable<TEntity>> Get();
        Task<IEnumerable<TEntity>> Get(Expression<Func<TEntity, bool>> predicate, params Expression<Func<TEntity, object>>[] includes);
        Task<TEntity> GetById(int id);
        Task<int> Create(TEntity entity);
        Task<TEntity> Find(Expression<Func<TEntity, bool>> predicate, params Expression<Func<TEntity, object>>[] includes);
    }
}
