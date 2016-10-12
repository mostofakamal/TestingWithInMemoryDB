using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Data.LoanApplication;
using Effort;
using Ninject;
using NUnit.Framework;
using Repository.UnitOfWork;
using Service;

namespace RepoTest
{

    public abstract class LoanServiceTestBase
    {
        protected ILoanApplicationContext LoanContext;
        protected DbConnection DbConnection;
        protected ILoanService LoanService;
        protected ILoanApplicationUnitOfWork LoanUnitOfWork;
        [TestFixtureSetUp]
        public void Init()
        {
            var kernel = new StandardKernel();

            DbConnection = DbConnectionFactory.CreateTransient();
            kernel.Bind<ILoanApplicationContext>().To<LoanApplicationContext>()
                .WithConstructorArgument("connection", DbConnection);
            kernel.Bind<ILoanApplicationUnitOfWork>().To<LoanApplicationUnitOfWork>();
            kernel.Bind<ILoanService>().To<LoanService>();

            LoanContext = kernel.Get<ILoanApplicationContext>();
            LoanService = kernel.Get<ILoanService>();
            LoanUnitOfWork = kernel.Get<ILoanApplicationUnitOfWork>();
        }

        [TestFixtureTearDown]
        public void Dispose()
        {
            DbConnection.Dispose();
            LoanContext.Dispose();
        }
    }
}
