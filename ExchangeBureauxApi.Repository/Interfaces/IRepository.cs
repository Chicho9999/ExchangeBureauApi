using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace ExchangeBureauxApi.Repository.Interfaces
{
    public interface IRepository<T> where T:class
    {
        IQueryable<T> GetAll();
        Task<IEnumerable<T>> GetAllAsync();
        IQueryable<T> GetAll(Expression<Func<T, bool>> whereClause, params Expression<Func<T, object>>[] includes);
        //PagedResultList<T> GetAll(PagingCriteria paging, params Expression<Func<T, object>>[] includes);
        //PagedResultList<T> GetAll(PagingCriteria paging, Expression<Func<T, bool>> whereClause, params Expression<Func<T, object>>[] includes);
        T Get(int id, params Expression<Func<T, object>>[] includes);
        Task<T> GetAsync(int id, params Expression<Func<T, object>>[] includes);
        T Get(Expression<Func<T, bool>> whereClause, params Expression<Func<T, object>>[] includes);
        Task<T> GetAsync(Expression<Func<T, bool>> whereClause, params Expression<Func<T, object>>[] includes);
        void Add(T entity);
        Task AddAsync(T entity);
        Task AddBulk(IEnumerable<T> entities);
        void Update(T entity);
        void Delete(T entity);
        void Delete(int id);
    }
}
