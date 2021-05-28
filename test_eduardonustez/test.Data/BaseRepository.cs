using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using test.Domain;
using test.Domain.Contracts;
using test.Domain.Entities;

namespace test.Data
{
    public class BaseRepository<TEntity> : IBaseRepository<TEntity>
        where TEntity:EntidadBase
    {
        private readonly testContext _testContext;
        public BaseRepository(testContext context)
        {
            _testContext = context;
        }
        protected DbSet<TEntity> GetSet()
        {
            return _testContext.Set<TEntity>();
        }

        public virtual async Task<int> Create(TEntity entity)
        {
            GetSet().Add(entity);
            await _testContext.SaveChangesAsync();
            return entity.Id;
        }
        public virtual async Task<IEnumerable<TEntity>> Get()
        {
            return await GetSet().ToListAsync();
        }
        public virtual async Task<IEnumerable<TEntity>> Get(Expression<Func<TEntity, bool>> predicate, params Expression<Func<TEntity, object>>[] includes)
        {
            var set = GetSet().Where(predicate);
            foreach (var item in includes)
            {
                set = set.Include(item);
            }
            return await set.ToListAsync();
        }
        public virtual async Task<TEntity> Find(Expression<Func<TEntity, bool>> predicate, params Expression<Func<TEntity, object>>[] includes)
        {
            var set = GetSet().Where(predicate);
            foreach (var item in includes)
            {
                set = set.Include(item);
            }
            return await set.FirstOrDefaultAsync();
        }
        public virtual async Task<TEntity> GetById(int id)
        {
            return await GetSet().FindAsync(id);
        }

        public void Dispose()
        {
            _testContext.Dispose();
        }

    }
}
