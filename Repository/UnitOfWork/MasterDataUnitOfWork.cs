using System;
using System.Collections.Generic;
using System.Linq;
using Data.MasterValue;
using Data.MasterValue.Models;
using Data.Models;
using Repository.Repositories;

namespace Repository.UnitOfWork
{
    public class MasterDataUnitOfWork : IMasterDataUnitOfWork
    {
        private readonly MasterValuesContext _context = null;

        public MasterDataUnitOfWork()
        {
            _context = new MasterValuesContext();
        }

        private Dictionary<Type, object> Repositories = new Dictionary<Type, object>();

        public IRepository<T> Repository<T>() where T : class, IMasterData
        {
            if (Repositories.Keys.Contains(typeof(T)))
            {
                return Repositories[typeof(T)] as IRepository<T>;
            }
            IRepository<T> repo = new RepositoryBase<T>(_context);
            Repositories.Add(typeof(T), repo);
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
