using System;
using System.Data.Entity;
using Data.LoanApplication.Models;
using Data.Models;

namespace Data.LoanApplication
{
    public interface ILoanApplicationContext:IDisposable
    {
        DbSet<tblBalance> tblBalances { get; set; }
        DbSet<tblLoanApplication> tblLoanApplications { get; set; }

        DbSet<TEntity> Set<TEntity>() where TEntity : class;

        int SaveChanges();
    }
}