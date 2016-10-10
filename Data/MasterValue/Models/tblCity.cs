using System;
using System.Collections.Generic;
using Data.MasterValue.Models;

namespace Data.Models
{
    public partial class tblCity: IMasterData
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
}
