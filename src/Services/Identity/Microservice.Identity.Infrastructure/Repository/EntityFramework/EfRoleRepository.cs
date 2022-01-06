using Microservice.Identity.Application.Repository;
using Microservice.Identity.Domain.Context;
using Microservice.Identity.Domain.Entity;
using Microservices.Core.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Microservice.Identity.Infrastructure.Repository.EntityFramework
{
    public class EfRoleRepository : EfRepository<IdentityDbContext, Role, string>, IRoleRepository
    {
        private readonly IdentityDbContext _context;

        public EfRoleRepository(IdentityDbContext context):base(context)
        {

        }
    }
}
