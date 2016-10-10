using System;
using System.Data.Common;
using System.Data.Entity.Infrastructure;
using Data.LoanApplication;
using Data.Models;
using Effort;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NUnit.Framework;
using Repository.UnitOfWork;
using Service;

namespace RepoTest
{
    [TestFixture]
    public class LoanIntegrationTests
    {
        private LoanApplicationContext _loanContext;
        private DbConnection dbConnection;
        private LoanService _loanService;

        [SetUp]
        public void Init()
        {
            dbConnection = DbConnectionFactory.CreateTransient();
            _loanContext = new LoanApplicationContext(dbConnection);
            _loanService = new LoanService(new LoanApplicationUnitOfWork(_loanContext));
        }

        [TearDown]
        public void Dispose()
        {
            dbConnection.Dispose();
        }

        [Test]
        public void Create_AddALoanApplication_LoanApplicationCreated()
        {
            var loan = new tblLoanApplication
            {
                Name = "Sumon",
                Amount = 4509,
            };

            _loanService.CreteLoan(loan);
            var result = _loanService.GetLoan(1);
            (result.Amount).Should().Be(4509);
        }
    }
}
