using FEGenesisAppWeb.Models.Entities.Billing;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FEGenesisAppWeb.Models.Entities.Catalog
{
    [Table("IdentificationTypes", Schema = "Catalog")]
    public class IdentificationTypeModel
    {
        public string ID { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;

        [JsonIgnore]
        public ICollection<CustomerModel>? Customers { get; }
    }
}
