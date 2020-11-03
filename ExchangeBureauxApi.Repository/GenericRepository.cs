using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using ExchangeBureauxApi.Data.Models;
using ExchangeBureauxApi.Repository.Interfaces;

namespace ExchangeBureauxApi.Repository
{
    public class GenericRepository<T> : IRepository<T> where T : class
    {
        private readonly CurrencyExchangeDbContext _DBContext;
        private readonly DbSet<T> _DbSet;

        public GenericRepository(CurrencyExchangeDbContext DbContext)
        {
            _DBContext = DbContext;
            _DbSet = _DBContext.Set<T>();
        }


        public void Add(T entity)
        {
            _DbSet.Add(entity);
        }
        public async Task AddAsync(T entity)
        {
            await _DbSet.AddAsync(entity);
        }

        public async Task AddBulk(IEnumerable<T> entities)
        {
            await _DbSet.AddRangeAsync(entities);
        }

        public void Delete(T entity)
        {
            _DbSet.Remove(entity);
        }

        public void Delete(int id)
        {
            var entity = _DbSet.Find(id);
            if (entity != null)
                _DbSet.Remove(entity);
        }

        public void DeleteBulk(IEnumerable<T> entities)
        {
            _DbSet.RemoveRange(entities);
        }

        public T Get(int id, params Expression<Func<T, object>>[] includes)
        {
            foreach (var include in includes)
            {
                _DbSet.Include(include);
            }
            return _DbSet.Find(id);
        }

        public async Task<T> GetAsync(int id, params Expression<Func<T, object>>[] includes)
        {
            foreach (var include in includes)
            {
                _DbSet.Include(include);
            }
            return await _DbSet.FindAsync(id);
        }

        public T Get(Expression<Func<T, bool>> whereClause, params Expression<Func<T, object>>[] includes)
        {
            var dbset = _DbSet.AsQueryable();
            foreach (var include in includes)
            {
                dbset = dbset.Include(include);
            }
            return dbset.FirstOrDefault(whereClause);
        }

        public IQueryable<T> GetAll()
        {
            return _DbSet.AsQueryable();
        }

        public async Task<IEnumerable<T>> GetAllAsync()
        {
            return await _DbSet.ToListAsync();
        }

        public IQueryable<T> GetAll(Expression<Func<T, bool>> whereClause, params Expression<Func<T, object>>[] includes)
        {
            var dbset = _DbSet.AsQueryable();
            if (whereClause != null)
            {
                dbset = dbset.Where(whereClause).AsQueryable();
            }

            foreach (var include in includes)
            {
                dbset = dbset.Include(include);
            }

            return dbset;
        }

        public async Task<T> GetAsync(Expression<Func<T, bool>> whereClause, params Expression<Func<T, object>>[] includes)
        {
            var dbset = _DbSet.AsQueryable();
            foreach (var include in includes)
            {
                dbset = dbset.Include(include);
            }
            return await dbset.FirstOrDefaultAsync(whereClause);
        }

        public void Update(T entity)
        {
            var dbEntityEntry = _DBContext.Entry(entity);
            if (dbEntityEntry.State == EntityState.Detached)
            {
                _DbSet.Attach(entity);
            }
            dbEntityEntry.State = EntityState.Modified;
        }
    }
}
