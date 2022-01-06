using Microservice.Identity.Application.Repository;
using Microservice.Identity.Domain.Entity;
using Microservices.Core.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Microservice.Identity.Infrastructure.Repository.Dapper
{
    public class DapperPermissionGroupRepository : DapperRepository<PermissionGroup,long>, IPermissionGroupRepository
    {
    }
}
