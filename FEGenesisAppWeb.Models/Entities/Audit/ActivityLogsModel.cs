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
    [Table("ActivityLogs", Schema = "Audit")]
    public class ActivityLogModel : BaseEntity, IHasTenant
    {
        public long TenantId { get; set; }
        public long? UserId { get; set; }
        public string Action { get; set; } = null!;
        public string EntityName { get; set; } = null!;
        public string? EntityId { get; set; }
        public string? OldValues { get; set; }
        public string? NewValues { get; set; }
        public string? IpAddress { get; set; }
        public string? UserAgent { get; set; }

        // Relaciones de navegación
        public virtual TenantModel Tenant { get; set; } = null!;
        public virtual UserModel? User { get; set; }
    }
}
