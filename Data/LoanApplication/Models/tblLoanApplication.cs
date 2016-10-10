using System;
using System.Collections.Generic;
using Data.LoanApplication.Models;

namespace Data.Models
{
    public partial class tblLoanApplication: ILoan
    {
        public int Id { get; set; }
        public Nullable<int> Amount { get; set; }
        public string Name { get; set; }

        public override string ToString()
        {
            return string.Format(" Id: {0} Name: {1} Amount : {2}", Id, Name, Amount ?? 0);
        }
    }
}
