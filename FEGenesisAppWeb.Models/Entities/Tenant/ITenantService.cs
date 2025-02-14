using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FEGenesisAppWeb.Models.Entities.Tenant
{
    public interface ITenantService
    {
        long GetCurrentTenantId();
        Task<TenantModel> GetCurrentTenant();
        // string GetTenantFromRequest();
        Task<bool> TenantExists(long tenantId);
        Task<bool> ValidateTenantAccess(long tenantId, long userId);
        Task EnsureValidTenant(long tenantId);
    }
}
