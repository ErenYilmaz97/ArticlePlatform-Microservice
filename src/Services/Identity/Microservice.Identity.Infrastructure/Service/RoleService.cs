using Microservice.Identity.Application.Service;
using Microservice.Identity.Application.UnitOfWork;
using Microservice.Identity.Domain.Entity;
using Microservices.Core.Utilities.Result.Business;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Microservice.Identity.Infrastructure.Service
{
    public class RoleService : IRoleService
    {
        private readonly IIdentityUnitOfWork _uow;

        public RoleService(IIdentityUnitOfWork uow)
        {
            _uow = uow;
        }


        public async Task<IBusinessDataResult<Role>> GetDefaultUserRole()
        {
            var defaultRole = await _uow.Roles.GetAsync(filter: x => x.IsDefault);
            return new SuccessBusinessDataResult<Role>(defaultRole, string.Empty);
        }
    }
}
