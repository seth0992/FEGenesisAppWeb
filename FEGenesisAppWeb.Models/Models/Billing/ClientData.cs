using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FEGenesisAppWeb.Models.Models.Billing
{
    public class ClientData
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public string IdentificationType { get; set; }
        public string Identification { get; set; }
        public string Email { get; set; }
        public string PhoneCode { get; set; }
        public string Phone { get; set; }
        public List<Exoneration> Exonerations { get; set; } = new();
    }
}
