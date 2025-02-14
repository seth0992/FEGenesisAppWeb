using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FEGenesisAppWeb.Models.Entities.Common
{
    public interface IHasTenant
    {
        long TenantId { get; set; }
    }
}
