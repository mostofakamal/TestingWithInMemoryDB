using System.Data.Entity;
using Data.LoanApplication;
using Data.Models;
using FluentAssertions;
using Moq;
using NUnit.Framework;
using Repository.Repositories;
using RepoTest.Extensions;

namespace RepoTest
{
    [TestFixture]
    public class LoanRepositoryTest
    {
        private RepositoryBase<tblLoanApplication> _loanApplicationRespository;
        private Mock<DbSet<tblLoanApplication>> _mockLoanApplications;
        private Mock<DbSet<tblBalance>> _mockBalances;

        [SetUp]
        public void Init()
        {
            _mockLoanApplications = new Mock<DbSet<tblLoanApplication>>();
            _mockBalances = new Mock<DbSet<tblBalance>>();
            var mockContext = new Mock<LoanApplicationContext>();
            //mockContext.SetupGet(c => c.tblLoanApplications).Returns(_mockLoanApplications.Object);
            //mockContext.SetupGet(c => c.tblBalances).Returns(_mockBalances.Object);
            mockContext.Setup(c => c.Set<tblLoanApplication>()).Returns(_mockLoanApplications.Object);
            _loanApplicationRespository = new RepositoryBase<tblLoanApplication>(mockContext.Object);
        }

        [Test]
        public void Get_AddTwoLoans_CorrectLoanIsRetrived()
        {
            var loan1 = new tblLoanApplication
            {
                Id = 1,
                Name = "sumon",
                Amount = 25000
            };
            var loan2 = new tblLoanApplication
            {
                Id = 2,
                Name = "Kamal",
                Amount = 3580
            };
            _mockLoanApplications.SetSource(new[] { loan1, loan2 });
            var result = _loanApplicationRespository.Get(c => c.Id == 1);
            (result).Should().NotBeNull();
            (result.Amount).Should().Be(25000);


        }
    }
}
