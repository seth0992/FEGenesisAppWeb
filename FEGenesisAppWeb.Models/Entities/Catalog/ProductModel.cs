using FEGenesisAppWeb.Models.Entities.Billing;
using FEGenesisAppWeb.Models.Entities.Common;
using FEGenesisAppWeb.Models.Entities.Tenant;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FEGenesisAppWeb.Models.Entities.Catalog
{
    [Table("Products", Schema = "Catalog")]
    public class ProductModel : BaseEntity, IHasTenant
    {
        public long TenantId { get; set; }

        [Required]
        [StringLength(50)]
        public string Code { get; set; } = null!;

        [Required]
        [StringLength(20)]
        public string CabysCode { get; set; } = null!;

        [Required]
        [StringLength(255)]
        public string Name { get; set; } = null!;

        [StringLength(500)]
        public string? Description { get; set; }

        [Column(TypeName = "decimal(18,2)")]
        public decimal UnitPrice { get; set; }

        [Required]
        [StringLength(50)]
        public string UnitOfMeasure { get; set; } = null!;

        public long TaxTypeId { get; set; }

        public bool IsService { get; set; }

        // Relaciones de navegación
        public virtual TenantModel Tenant { get; set; } = null!;
        public virtual TaxTypeModel TaxType { get; set; } = null!;
        public virtual ICollection<InvoiceLineModel> InvoiceLines { get; set; } = new List<InvoiceLineModel>();
    }
}
