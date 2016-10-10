using System.Data.Entity;
using Data.Models;

namespace Data.LoanApplication
{
    public interface ILoanApplicationContext
    {
        DbSet<tblBalance> tblBalances { get; set; }
        DbSet<tblLoanApplication> tblLoanApplications { get; set; }

        DbSet<TEntity> Set<TEntity>() where TEntity : class;
    }
}