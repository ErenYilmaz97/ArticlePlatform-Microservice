using Microservice.Identity.Application.Repository;
using Microservices.Core.UnitOfWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Microservice.Identity.Application.UnitOfWork
{
    public interface IIdentityUnitOfWork : IUnitOfWork
    {
         IUserRepository Users { get;}
         IRoleRepository Roles { get; }
         IPermissionRepository Permissions { get; }
         IPermissionGroupRepository PermissionGroups { get; }
         ILoginHistoryRepository LoginHistories { get; }
         IUserActionHistoryRepository UserActionHistories { get; }
         IUserCommonTokenRepository UserCommonTokens { get; }
         ISubscribedClientRepository SubscribedClients { get; }
    }
}
