using FEGenesisAppWeb.Models.Entities.Billing;
using FEGenesisAppWeb.Models.Entities.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FEGenesisAppWeb.Models.Entities.Catalog
{
    [Table("DocumentTypes", Schema = "Catalog")]
    public class DocumentTypeModel : BaseEntity
    {
        [Required]
        [StringLength(10)]
        public string Code { get; set; } = null!;

        [Required]
        [StringLength(100)]
        public string Name { get; set; } = null!;

        [StringLength(255)]
        public string? Description { get; set; }

        // Relaciones de navegación
        public virtual ICollection<InvoiceModel> Invoices { get; set; } = new List<InvoiceModel>();
    }
}
