﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using FEGenesisAppWeb.Models.Entities.Billing;

namespace FEGenesisAppWeb.Models.Entities.Catalog
{
    [Table("Districts", Schema = "Catalog")]
    public class DistrictModel
    {
        [Key]
        public int DistrictID { get; set; }
        public string DistrictName { get; set; } = string.Empty;
        public int CantonId { get; set; }
        public int RegionID { get; set; }

        public CantonModel? Canton { get; set; }
        public RegionModel? Region { get; set; }

        [JsonIgnore]
        public ICollection<CustomerModel>? CustomerModels { get; }
    }
}
