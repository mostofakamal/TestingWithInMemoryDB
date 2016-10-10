using System.Data.Entity;
using Data.Models;

namespace Data.MasterValue
{
    public interface IMasterValuesContext
    {
        DbSet<tblCity> tblCities { get; set; }

        DbSet<TEntity> Set<TEntity>() where TEntity : class;
    }
}