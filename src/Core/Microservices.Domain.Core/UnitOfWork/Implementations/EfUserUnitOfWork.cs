using Microservice.User.Domain.Context;
using Microservices.Domain.Core.UnitOfWork.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Microservices.Domain.Core.UnitOfWork.Implementations
{
    public class EfUserUnitOfWork : EfUnitOfWork<UserDbContext>, IUserUnitOfWork
    {
        private readonly UserDbContext _context;

        public EfUserUnitOfWork(UserDbContext context) : base(context)
        {
            _context = context;
        }
    }
}
