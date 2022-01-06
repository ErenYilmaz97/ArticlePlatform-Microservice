using Microservice.Identity.Application.Repository;
using Microservice.Identity.Application.UnitOfWork;
using Microservice.Identity.Domain.Context;
using Microservice.Identity.Infrastructure.Repository.EntityFramework;
using Microservices.Core.UnitOfWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Microservice.Identity.Infrastructure.UnitOfWork
{
    public class IdentityUnitOfWork :  EfUnitOfWork<IdentityDbContext> ,IIdentityUnitOfWork
    {
        public IdentityUnitOfWork(IdentityDbContext context):base(context)
        {
            #region Initializing Lazy Objects
            this.UserRepository = new Lazy<IUserRepository>(() => new EfUserRepository(context));
            this.RoleRepository = new Lazy<IRoleRepository>(() => new EfRoleRepository(context));
            this.PermissionRepository = new Lazy<IPermissionRepository>(() => new EfPermissionRepository(context));
            this.LoginHistoryRepository = new Lazy<ILoginHistoryRepository>(() => new EfLoginHistoryRepository(context));
            this.UserCommonTokenRepository = new Lazy<IUserCommonTokenRepository>(() => new EfUserCommonTokenRepository(context));
            this.PermissionGroupRepository = new Lazy<IPermissionGroupRepository>(() => new EfPermissionGroupRepository(context));
            this.SubscribedClientRepository = new Lazy<ISubscribedClientRepository>(() => new EfSubscribedClientRepository(context));
            this.UserActionHistoryRepository = new Lazy<IUserActionHistoryRepository>(() => new EfUserActionHistoryRepository(context));
            #endregion
        }



        #region Repositories
        public IUserRepository Users { get => this.UserRepository.Value; }
        public IRoleRepository Roles { get => this.RoleRepository.Value; }
        public IPermissionRepository Permissions { get => this.PermissionRepository.Value; }
        public IPermissionGroupRepository PermissionGroups { get => this.PermissionGroupRepository.Value; }
        public ILoginHistoryRepository LoginHistories { get => this.LoginHistoryRepository.Value; }
        public IUserActionHistoryRepository UserActionHistories { get => this.UserActionHistoryRepository.Value; }
        public IUserCommonTokenRepository UserCommonTokens { get => this.UserCommonTokenRepository.Value; }
        public ISubscribedClientRepository SubscribedClients { get => this.SubscribedClientRepository.Value; }
        #endregion



        #region Lazy Objects
        public Lazy<IUserRepository> UserRepository { get;}
        public Lazy<IRoleRepository> RoleRepository { get;}
        public Lazy<IPermissionRepository> PermissionRepository { get;}
        public Lazy<IPermissionGroupRepository> PermissionGroupRepository { get;}
        public Lazy<ILoginHistoryRepository> LoginHistoryRepository { get;}
        public Lazy<IUserActionHistoryRepository> UserActionHistoryRepository { get;}
        public Lazy<IUserCommonTokenRepository> UserCommonTokenRepository { get;}
        public Lazy<ISubscribedClientRepository> SubscribedClientRepository { get;}
        #endregion
    }
}
