using SonsuzbilgiV2.Shared.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace SonsuzbilgiV2.Shared.Data.Abstract
{
    public interface IEntityRepository<T>  where T: class,IEntity,new()
    {
        Task<T> GetAsync(Expression<Func<T, bool>> predicate,params Expression<Func<T,
            object>>[] includePropterties);
        Task<IList<T>> GetAllAsync(Expression<Func<T, bool>> predicate=null,
            params Expression<Func<T, object>>[] includePropteries);
        Task<T> GetByIdAsync(int id);
        Task<T> SingleOrDefaultAsync(Expression<Func<T, bool>> predicate);
        Task<bool> AnyAsync(Expression<Func<T, bool>> predicate);
        Task<int> CountAsync(Expression<Func<T, bool>> predicate);
        Task<T> AddAsync(T Entity);
        Task<T> UpdateAsync(T Entity);
        Task DeleteAsync(T Entity);
        

    }
}
