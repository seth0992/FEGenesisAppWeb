using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FEGenesisAppWeb.Models.Models.Settings
{
    public class ResetPasswordDto
    {
        public long UserId { get; set; }
        public bool SendEmail { get; set; }
        public string NewPassword { get; set; }
    }
}
