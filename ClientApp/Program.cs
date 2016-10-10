using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Data.Models;
using Ninject;
using Repository.UnitOfWork;
using Service;

namespace ClientApp
{
    class Program
    {
        static void Main(string[] args)
        {
            var kernel = new StandardKernel();
            kernel.Bind<ILoanService>().To<LoanService>();
            kernel.Bind<ILoanApplicationUnitOfWork>().To<LoanApplicationUnitOfWork>();
            var loanService = kernel.Get<ILoanService>();
            var result = loanService.GetLoan(1);
            Console.WriteLine(result.Name);
            var loan = new tblLoanApplication
            {
                Name = "Test",
                Amount = 3400,
                Id=3434
            };
            loanService.CreteLoan(loan);

        }
    }
}
