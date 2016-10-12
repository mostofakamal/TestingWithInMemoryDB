using System.Data.Common;
using System.Data.Entity;
using Data.LoanApplication.Models;
using Data.Models;
using Data.Models.Mapping;

namespace Data.LoanApplication
{
    public partial class LoanApplicationContext : DbContext, ILoanApplicationContext
    {
        static LoanApplicationContext()
        {
            Database.SetInitializer<LoanApplicationContext>(null);
        }

        public LoanApplicationContext()
            : base("Name=LoanApplicationContext")
        {
        }

        public LoanApplicationContext(DbConnection connection) : base(connection, true)
        {
            this.Database.CreateIfNotExists();
        }
        public DbSet<tblBalance> tblBalances { get; set; }
        public DbSet<tblLoanApplication> tblLoanApplications { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new tblBalanceMap());
            modelBuilder.Configurations.Add(new tblLoanApplicationMap());
        }
    }
}
