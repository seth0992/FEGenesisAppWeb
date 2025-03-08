using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FEGenesisAppWeb.Models.Models.Settings
{
    public class CertificateUploadDto
    {
        public string Name { get; set; }
        public string Password { get; set; }
        public byte[] CertificateData { get; set; }
        public bool IsDefault { get; set; }
    }
}
