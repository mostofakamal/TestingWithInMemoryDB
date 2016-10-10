using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Data.Models;

namespace Service
{
    public interface ILoanService
    {
        tblLoanApplication GetLoan(int id);
        void CreteLoan(tblLoanApplication  loan);
    }
}
