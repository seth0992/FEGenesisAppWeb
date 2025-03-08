using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FEGenesisAppWeb.Models.Models.Settings
{
    public class CertificateInfoDto
    {
        public string IssuerName { get; set; }
        public string SubjectName { get; set; }
        public DateTime ExpirationDate { get; set; }
        public string SerialNumber { get; set; }
        public bool IsValid { get; set; }
        public string[] Purposes { get; set; }
    }
}
