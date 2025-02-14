using FEGenesisAppWeb.Models.Entities.Common;
using FEGenesisAppWeb.Models.Entities.Security;
using FEGenesisAppWeb.Models.Entities.Tenant;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
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


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            
            modelBuilder.Entity<SecurityLogModel>(entity =>
            {
                entity.Property(e => e.EventType)
                    .HasMaxLength(50)
                    .IsRequired();

                entity.Property(e => e.Email)
                    .HasMaxLength(255)
                    .IsRequired();

                entity.Property(e => e.IpAddress)
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<UserModel>(entity =>
            {
                entity.Property(e => e.SecurityStamp)
                    .HasMaxLength(450); // O el tamaño que prefieras

                entity.Property(e => e.LastPasswordChangeDate)
                    .IsRequired(false);

                entity.Property(e => e.LastSuccessfulLogin)
                    .IsRequired(false);
            });


            foreach (var entityType in modelBuilder.Model.GetEntityTypes())
            {
                if (typeof(IHasTenant).IsAssignableFrom(entityType.ClrType))
                {
                    var parameter = Expression.Parameter(entityType.ClrType, "e");
                    var property = Expression.Property(parameter, "TenantId");
                    var value = Expression.Constant(_tenantService.GetCurrentTenantId());
                    var body = Expression.Equal(property, value);
                    var lambda = Expression.Lambda(body, parameter);

                    modelBuilder.Entity(entityType.ClrType).HasQueryFilter(lambda);
                }
            }

            // Aplicar filtro global por tenant
            //modelBuilder.Entity<CustomerModel>()
            //    .HasQueryFilter(x => x.TenantId == _tenantService.GetCurrentTenantId());

        }

    }
}
