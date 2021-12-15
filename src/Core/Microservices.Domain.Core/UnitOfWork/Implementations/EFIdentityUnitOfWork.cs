using Microservice.Identity.Domain.Context;
using Microservices.Domain.Core.UnitOfWork.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Microservices.Domain.Core.UnitOfWork.Implementations
{
    public class EFIdentityUnitOfWork :EfUnitOfWork<IdentityDbContext> , IIdentityUnitOfWork
    {
        private readonly IdentityDbContext _context;

        public EFIdentityUnitOfWork(IdentityDbContext context):base(context)
        {
            _context = context;
        }
    }
}
