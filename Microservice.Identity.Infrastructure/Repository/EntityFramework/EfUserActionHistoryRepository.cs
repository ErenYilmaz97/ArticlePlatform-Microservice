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
    public class EfUserActionHistoryRepository : EfRepository<IdentityDbContext, UserActionHistory, long> , IUserActionHistoryRepository
    {
        private readonly IdentityDbContext _context;

        public EfUserActionHistoryRepository(IdentityDbContext context):base(context)
        {

        }
    }
}
