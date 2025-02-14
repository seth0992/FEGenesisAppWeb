using FEGenesisAppWeb.Models.Entities.Security;
using FEGenesisAppWeb.Models.Entities.Tenant;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FEGenesisAppWeb.Database.Data
{
    public class AppDbContext : DbContext
    {

        private readonly ITenantService _tenantService;

        public AppDbContext(
            DbContextOptions<AppDbContext> options,
            ITenantService tenantService) : base(options)
        {
            _tenantService = tenantService;
            Database.EnsureCreated();
        }

        public DbSet<UserModel> Users { get; set; }
        public DbSet<RoleModel> Roles { get; set; }
        public DbSet<TenantModel> Tenants { get; set; }
        public DbSet<RefreshTokenModel> RefreshTokens { get; set; }
        public DbSet<SecurityLogModel> SecurityLogs { get; set; }
        public DbSet<SecretModel> Secrets { get; set; }

        //Subscription
        public DbSet<SubscriptionTypeModel> SubscriptionTypes { get; set; }
        public DbSet<SubscriptionHistoryModel> SubscriptionHistory { get; set; }



    }
}
