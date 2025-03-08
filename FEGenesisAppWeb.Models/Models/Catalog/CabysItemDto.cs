using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FEGenesisAppWeb.Models.Models.Catalog
{
    public class CabysItemDto
    {
        public string Code { get; set; }
        public string Description { get; set; }
        public decimal TaxRate { get; set; }
        public string Category { get; set; }
        public bool IsService { get; set; }
    }
}
