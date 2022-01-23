using Microservice.Identity.Domain.Entity;
using Microservice.Identity.Domain.EntityConfigurations;
using Microservices.Core.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Microservice.Identity.Domain.Context
{
    public class IdentityDbContext : EfDbContext
    {
        public IdentityDbContext(DbContextOptions<IdentityDbContext> opts) : base(opts)
        {
            //ConString Injection
        }



        public DbSet<User> Users { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<PermissionGroup> PermissionGroups { get; set; }
        public DbSet<Permission> Permission { get; set; }
        public DbSet<LoginHistory> LoginHistories { get; set; }
        public DbSet<UserActionHistory> UserActionHistories { get; set; }
        public DbSet<UserCommonToken> UserCommonTokens { get; set; }
        public DbSet<SubscribedClient> SubscribedClients { get; set; }



        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfiguration(new UserEntityConfiguration());
            builder.ApplyConfiguration(new RoleEntityConfiguration());
            builder.ApplyConfiguration(new PermissionGroupEntityConfiguration());
            builder.ApplyConfiguration(new PermissionEntityConfiguration());
            builder.ApplyConfiguration(new LoginHistoryEntityConfiguration());
            builder.ApplyConfiguration(new UserActionHistoryEntityConfiguration());
            builder.ApplyConfiguration(new UserCommonTokenEntityConfiguration());
            builder.ApplyConfiguration(new SubscribedClientEntityConfiguration());

            base.OnModelCreating(builder);
        }

    }
}
