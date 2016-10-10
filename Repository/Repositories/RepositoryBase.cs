using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using Data.LoanApplication;
using Data.LoanApplication.Models;

namespace Repository.Repositories
{
    public class RepositoryBase<T>: IRepository<T> where T : class
    {
        protected readonly DbContext _context;
        public RepositoryBase(DbContext context)
        {
            _context = context;
        }

        public IEnumerable<T> GetAll(Func<T, bool> predicate = null)
        {
            if (predicate != null)
            {
                return Enumerable.Where(_context.Set<T>(), predicate);
            }

            return Enumerable.AsEnumerable<T>(_context.Set<T>());
        }

        public T Get(Func<T, bool> predicate)
        {
            return Enumerable.First(_context.Set<T>(), predicate);
        }

        public void Add(T entity)
        {
            _context.Set<T>().Add(entity);
        }

        public void Attach(T entity)
        {
            _context.Set<T>().Attach(entity);
        }

        public void Delete(T entity)
        {
            _context.Set<T>().Remove(entity);
        }
    }
}