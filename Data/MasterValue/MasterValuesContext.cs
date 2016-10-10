using System.Data.Entity;
using Data.Models;
using Data.Models.Mapping;

namespace Data.MasterValue
{
    public partial class MasterValuesContext : DbContext, IMasterValuesContext
    {
        static MasterValuesContext()
        {
            Database.SetInitializer<MasterValuesContext>(null);
        }

        public MasterValuesContext()
            : base("Name=MasterValuesContext")
        {
        }

        public DbSet<tblCity> tblCities { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new tblCityMap());
        }
    }
}
