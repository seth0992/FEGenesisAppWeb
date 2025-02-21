using FEGenesisAppWeb.Models.Entities.Common;
using FEGenesisAppWeb.Models.Entities.Security;
using FEGenesisAppWeb.Models.Entities.Tenant;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FEGenesisAppWeb.Models.Entities.Notifications
{
    [Table("Notifications", Schema = "Notifications")]
    public class NotificationModel : BaseEntity, IHasTenant
    {
        public long TenantId { get; set; }
        public long TemplateId { get; set; }
        public long UserId { get; set; }
        public string Title { get; set; } = null!;
        public string Message { get; set; } = null!;
        public string Type { get; set; } = null!;
        public bool IsRead { get; set; }
        public DateTime? ReadAt { get; set; }

        // Relaciones de navegación
        public virtual TenantModel Tenant { get; set; } = null!;
        public virtual TemplateModel Template { get; set; } = null!;
        public virtual UserModel User { get; set; } = null!;
        public virtual ICollection<NotificationDeliveryModel> Deliveries { get; set; } = new List<NotificationDeliveryModel>();
    }
}
