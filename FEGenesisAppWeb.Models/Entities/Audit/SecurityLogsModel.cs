using FEGenesisAppWeb.Models.Entities.Common;
using FEGenesisAppWeb.Models.Entities.Security;
using FEGenesisAppWeb.Models.Entities.Tenant;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FEGenesisAppWeb.Models.Entities.Audit
{
    [Table("SecurityLogs", Schema = "Audit")]
    public class SecurityLogsModel : BaseEntity
    {
        public long? TenantId { get; set; }
        public long? UserId { get; set; }
        public string EventType { get; set; } = null!;
        public string? Description { get; set; }
        public string? IpAddress { get; set; }

        // Relaciones de navegación
        public virtual TenantModel? Tenant { get; set; }
        public virtual UserModel? User { get; set; }
    }
}
