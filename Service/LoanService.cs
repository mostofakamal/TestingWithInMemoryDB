using System.Linq;
using Data.Dtos;
using Data.Models;
using Repository.UnitOfWork;

namespace Service
{
    public class LoanService : ILoanService
    {
        private readonly ILoanApplicationUnitOfWork _uow;
        public LoanService(ILoanApplicationUnitOfWork uow)
        {
            this._uow = uow;
        }

        public tblLoanApplication GetLoan(int id)
        {
            return _uow.Repository<tblLoanApplication>().Get(l => l.Id == id);
        }

        public void CreteLoan(tblLoanApplication  loan)
        {
            _uow.Repository<tblLoanApplication>().Add(loan);
            _uow.SaveChanges();
        }

        public LoanWithBalance GetLoanApplicationWithBalance(string name)
        {
           
            var loanApplication = _uow.Repository<tblLoanApplication>().Get(c => c.Name == name);
            var balance = _uow.Repository<tblBalance>().Get(b => b.Name == name);
            var loanwithBalance= new LoanWithBalance();
            if (loanApplication.Amount > 1000)
            {
                loanwithBalance.Name = loanApplication.Name;
                loanwithBalance.BalanceAmount = balance.Balance;
                loanwithBalance.LoanAmount = loanApplication.Amount;
            }
            return loanwithBalance;
        }


    }
}