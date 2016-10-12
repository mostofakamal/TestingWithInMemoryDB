using Data.MasterValue.Models;
using Repository.Repositories;

namespace Repository.UnitOfWork
{
    public interface IMasterDataUnitOfWork: IUnitOfWork
    {
        IRepository<T> Repository<T>() where T : class, IMasterData;
    }
}
