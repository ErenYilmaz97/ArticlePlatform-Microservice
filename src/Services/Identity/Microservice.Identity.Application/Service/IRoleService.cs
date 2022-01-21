using Microservice.Identity.Domain.Entity;
using Microservices.Core.Utilities.Result.Business;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Microservice.Identity.Application.Service
{
    public interface IRoleService
    {
        Task<IBusinessDataResult<Role>> GetDefaultUserRole();
    }
}
