using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FEGenesisAppWeb.Models.Models.Settings
{
    public class CertificateDto
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public DateTime ExpirationDate { get; set; }
        public DateTime CreatedAt { get; set; }
        public bool IsActive { get; set; }
        public bool IsDefault { get; set; }
        public string IssuerName { get; set; }
        public string SubjectName { get; set; }
        public int NotificationsSent { get; set; }
    }
}
