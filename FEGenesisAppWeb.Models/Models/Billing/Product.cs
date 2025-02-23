using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FEGenesisAppWeb.Models.Models.Billing
{
    public class Product
    {
        public string Code { get; set; }
        public string CabysCode { get; set; }
        public string Description { get; set; }
        public decimal UnitPrice { get; set; }
        public string TaxCode { get; set; }
        public decimal TaxRate { get; set; }
    }
}
