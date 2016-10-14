using Data.Models;
using FluentAssertions;
using NUnit.Framework;

namespace RepoTest
{
    [TestFixture]
    public class LoanIntegrationTests : LoanServiceTestBase
    {
        [Test]
        public void Create_AddALoanApplication_LoanApplicationCreated()
        {
            var firstLoan = new tblLoanApplication
            {
                Amount = 33434,
                Name = "Mostofa"
            };
            LoanUnitOfWork.Repository<tblLoanApplication>().Add(firstLoan);
            LoanUnitOfWork.SaveChanges();
            var loan = new tblLoanApplication
            {
                Name = "Sumon",
                Amount = 4509,
            };
            LoanService.CreteLoan(loan);
            var result = LoanService.GetLoan(loan.Id);
            (result.Amount).Should().Be(4509);
        }

        [Test]
        public void Create_AddAnotherLoanApplication_LoanApplicationCreated()
        {
            var loan = new tblLoanApplication
            {
                Name = "Kamal",
                Amount = 300,
            };

            LoanService.CreteLoan(loan);
            var result = LoanService.GetLoan(loan.Id);
            (result.Name).Should().Be("Kamald");
        }
    }
}
