using Microservices.Domain.Core.UnitOfWork.Abstract;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Microservices.Domain.Core.UnitOfWork.Implementations
{
    public abstract class EfUnitOfWork<TContext> : IUnitOfWork where TContext : DbContext, new()
    {
        private readonly TContext _context;

        protected EfUnitOfWork(TContext context)
        {
            _context = context;
        }

        public void CommitChanges()
        {
            _context.SaveChanges();
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
