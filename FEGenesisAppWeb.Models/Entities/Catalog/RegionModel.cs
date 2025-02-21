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
    [Table("Region", Schema = "Catalog")]
    public class RegionModel
    {
        [Key]
        public int RegionID { get; set; }
        public string RegionName { get; set; } = string.Empty;

        [JsonIgnore]
        public ICollection<DistrictModel>? Districts { get; }
    }
}
