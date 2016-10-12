using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using Data.LoanApplication;
using Data.LoanApplication.Models;
using Data.Models;
using Repository.Repositories;

namespace Repository.UnitOfWork
{
    public class LoanApplicationUnitOfWork : ILoanApplicationUnitOfWork
    {
        private readonly ILoanApplicationContext _context = null;

        public LoanApplicationUnitOfWork(ILoanApplicationContext context)
        {
            _context = context ?? new LoanApplicationContext();
        }

        private Dictionary<Type, object> _repositories = new Dictionary<Type, object>();

        public IRepository<T> Repository<T>() where T : class, ILoan
        {
            if (_repositories.Keys.Contains(typeof(T)))
            {
                return _repositories[typeof (T)] as IRepository<T>;
            }
            IRepository<T> repo = new RepositoryBase<T>((DbContext)_context);
            _repositories.Add(typeof(T), repo);
            return repo;
        }

        public void SaveChanges()
        {
            _context.SaveChanges();
        }

        private bool _disposed;

        protected virtual void Dispose(bool disposing)
        {
            if (!this._disposed)
            {
                if (disposing)
                {
                    _context.Dispose();
                }
            }
            this._disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
