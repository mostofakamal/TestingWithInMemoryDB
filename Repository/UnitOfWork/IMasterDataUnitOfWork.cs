using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Data.MasterValue.Models;
using Repository.Repositories;

namespace Repository.UnitOfWork
{
    public interface IMasterDataUnitOfWork: IDisposable
    {
        IRepository<T> Repository<T>() where T : class, IMasterData;
        void SaveChanges();
    }
}
