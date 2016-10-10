using System;
using System.Collections.Generic;
using Data.LoanApplication.Models;

namespace Data.Models
{
    public partial class tblBalance : ILoan
    {
        public int Id { get; set; }
        public int? Balance { get; set; }
        public string Name { get; set; }
    }
}
