using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace BookStore.Core.Repository
{
    public interface IRepository<T> where T : class
    {
        Task<IEnumerable<T>> GetAllEntities();
        Task<IList<T>> GetAllEntitiesWithCriteria(Expression<Func<T, bool>> criteria);
        Task<T> GetEntityById(int id);
        Task<int> Add(T entity);
        Task Update(T entity);
        Task Remove(T entity);
    }
}
