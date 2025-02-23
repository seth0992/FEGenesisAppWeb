using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FEGenesisAppWeb.Models.Models.Billing
{
    public class Exoneration
    {
        public string DocumentNumber { get; set; }
        public string DocumentType { get; set; }
        public DateTime ExpirationDate { get; set; }
        public decimal Percentage { get; set; }
    }
}
