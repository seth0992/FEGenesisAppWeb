using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FEGenesisAppWeb.Models.Models.Billing
{
    public class InvoiceLine
    {
        public int LineNumber { get; set; }
        public string Code { get; set; }
        public string CabysCode { get; set; }
        public string Description { get; set; }
        public decimal Quantity { get; set; }
        public decimal UnitPrice { get; set; }
        public decimal DiscountPercentage { get; set; }
        public string DiscountReason { get; set; }
        public decimal DiscountAmount { get; set; }
        public string TaxCode { get; set; }
        public decimal TaxRate { get; set; }
        public decimal ExonerationPercentage { get; set; }
        public string ExonerationDocument { get; set; }
        public decimal TaxAmount { get; set; }
        public decimal SubTotal { get; set; }
        public decimal Total { get; set; }
    }
}
