using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Data.LoanApplication.Models;
using Data.Models;
using FluentAssertions;
using Moq;
using NUnit.Framework;
using Repository.UnitOfWork;
using Service;

namespace RepoTest
{
    [TestFixture]
    public class LoanApplicationServiceTests
    {
        private LoanService _loanApplicationService;
        private Mock<ILoanApplicationUnitOfWork> _loanApplicationUow;

        [SetUp]
        public void Init()
        {
            _loanApplicationUow = new Mock<ILoanApplicationUnitOfWork>();
            _loanApplicationService = new LoanService(_loanApplicationUow.Object);
        }

        [Test]
        public void GetLoanApplicationWithBalance_LoanAmountUnder1000_NullValuesReturned()
        {
            var name = "sumon";
            var loanApplication = new tblLoanApplication
            {
                Name = name,
                Amount = 140,
                Id = 1
            };
            var balance = new tblBalance
            {
                Name = "sumon",
                Balance = 3500,
                Id = 3
            };
            _loanApplicationUow.Setup(l => l.Repository<tblLoanApplication>().Get(It.IsAny<Func<tblLoanApplication, bool>>()))
                .Returns(loanApplication);

            _loanApplicationUow.Setup(l => l.Repository<tblBalance>().Get(It.IsAny<Func<tblBalance, bool>>()))
                .Returns(balance);
            var result = _loanApplicationService.GetLoanApplicationWithBalance(name);

            (result.BalanceAmount).Should().Be(null);
            (result.LoanAmount).Should().Be(null);
        }

        [Test]
        public void GetLoanApplicationWithBalance_LoanAmountOver1000_ExactValuesResturned()
        {
            var name = "sumon";
            var loanApplication = new tblLoanApplication
            {
                Name = name,
                Amount = 14000,
            };
            var balance = new tblBalance
            {
                Name = "sumon",
                Balance = 4500,
            };
            _loanApplicationUow.Setup(l => l.Repository<tblLoanApplication>().Get(It.IsAny<Func<tblLoanApplication, bool>>()))
                .Returns(loanApplication);

            _loanApplicationUow.Setup(l => l.Repository<tblBalance>().Get(It.IsAny<Func<tblBalance, bool>>()))
                .Returns(balance);
            var result = _loanApplicationService.GetLoanApplicationWithBalance(name);

            (result.BalanceAmount).Should().Be(4500);
            (result.LoanAmount).Should().Be(14000);
        }


    }
}
