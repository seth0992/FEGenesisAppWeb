using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace FEGenesisAppWeb.Models.Entities.Catalog
{
    [Table("Provinces", Schema = "Catalog")]
    public class ProvinceModel
    {
        [Key]
        public int ProvinceID { get; set; }
        public string ProvinceName { get; set; } = string.Empty;

        [JsonIgnore]
        public ICollection<CantonModel>? Cantons { get; }

    }
}
