using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using Data.MasterValue;
using Data.MasterValue.Models;
using Data.Models;
using Repository.Repositories;

namespace Repository.UnitOfWork
{
    public class MasterDataUnitOfWork : BaseUnitOfWork, IMasterDataUnitOfWork
    {
        public MasterDataUnitOfWork(IMasterValuesContext context) : base((DbContext)context)
        {
        }

        private readonly Dictionary<Type, object> _repositories = new Dictionary<Type, object>();

        public IRepository<T> Repository<T>() where T : class, IMasterData
        {
            if (_repositories.Keys.Contains(typeof(T)))
            {
                return _repositories[typeof(T)] as IRepository<T>;
            }
            IRepository<T> repo = new RepositoryBase<T>(_context);
            _repositories.Add(typeof(T), repo);
            return repo;
        }
    }
}
