﻿using Microsoft.EntityFrameworkCore;
using SonsuzbilgiV2.Shared.Data.Abstract;
using SonsuzbilgiV2.Shared.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace SonsuzbilgiV2.Shared.Concrete.EntityFramework
{
    public class EfEntityRepositoryBase<TEntity> : IEntityRepository<TEntity>
        where TEntity : class, IEntity, new()
    {
        protected readonly DbContext _Context;
        private readonly DbSet<TEntity> _dbSet;
        public EfEntityRepositoryBase(DbContext Context)
        {
            _Context = Context;
            _dbSet = Context.Set<TEntity>();
        }
        public async Task<TEntity> AddAsync(TEntity Entity)
        {
            await _dbSet.AddAsync(Entity);
            return Entity;
        }

        public async Task<bool> AnyAsync(Expression<Func<TEntity, bool>> predicate)
        {
            return await _dbSet.AnyAsync(predicate);
        }

        public async Task<int> CountAsync(Expression<Func<TEntity, bool>> predicate)
        {
            return await _dbSet.CountAsync(predicate);
        }

        public async Task DeleteAsync(TEntity Entity)
        {
            await Task.Run(() => { _dbSet.Remove(Entity); });
        }

        public async Task<IList<TEntity>> GetAllAsync(Expression<Func<TEntity, bool>> predicate = null, params Expression<Func<TEntity, object>>[] includePropteries)
        {
            IQueryable<TEntity> query = _Context.Set<TEntity>();
            if (predicate != null)
            {
                query = query.Where(predicate);
            }

            if (includePropteries.Any())
            {
                foreach (var includeProperty in includePropteries)
                {
                    query = query.Include(includeProperty);
                }
            }
            return await query.ToListAsync();
        }

        public async Task<TEntity> GetAsync(Expression<Func<TEntity, bool>> predicate, params Expression<Func<TEntity, object>>[] includePropterties)
        {
            IQueryable<TEntity> query = _Context.Set<TEntity>();
            query = query.Where(predicate);

            if (includePropterties.Any())
            {
                foreach (var includeProperty in includePropterties)
                {
                    query = query.Include(includeProperty);
                }
            }
            return await query.SingleOrDefaultAsync();
        }

        public async Task<TEntity> GetByIdAsync(int id)
        {
            return  null;
        }

        public async Task<TEntity> SingleOrDefaultAsync(Expression<Func<TEntity, bool>> predicate)
        {
            return await _dbSet.SingleOrDefaultAsync(predicate);
        }

        public async Task<TEntity> UpdateAsync(TEntity Entity)
        {
            await Task.Run(() => { _dbSet.Update(Entity); });
            return Entity;
        }
    }
}
