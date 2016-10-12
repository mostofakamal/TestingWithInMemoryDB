using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Data.LoanApplication.Models;
using Repository.Repositories;

namespace Repository.UnitOfWork
{
   public  interface ILoanApplicationUnitOfWork: IUnitOfWork
    {
       IRepository<T> Repository<T>() where T : class, ILoan;
      
    }
}
