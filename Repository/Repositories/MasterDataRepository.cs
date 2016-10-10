using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Data.MasterValue;
using Data.MasterValue.Models;
using Data.Models;

namespace Repository.Repositories
{
    public class MasterDataRepository<T> : RepositoryBase<T> where T : class, IMasterData
    {
        public MasterDataRepository(IMasterValuesContext context) : base((DbContext)context)
        {
        }
    }
}
