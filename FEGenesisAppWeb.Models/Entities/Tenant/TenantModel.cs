using FEGenesisAppWeb.Models.Entities.Common;
using FEGenesisAppWeb.Models.Entities.Security;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FEGenesisAppWeb.Models.Entities.Tenant
{
    [Table("Tenants", Schema = "Core")]
    public class TenantModel : BaseEntity
    {
        public string Name { get; set; } = null!;
        public string Identification { get; set; } = null!;
        public string? CommercialName { get; set; }
        public string? Email { get; set; }
        public string? Phone { get; set; }
        public string? Address { get; set; }
        public byte[]? Logo { get; set; }


        // Relaciones de navegación
        public virtual ICollection<UserModel> Users { get; set; } = new List<UserModel>();
        //public virtual ICollection<CustomerModel> Customers { get; set; } = new List<CustomerModel>();
        
    }
}
