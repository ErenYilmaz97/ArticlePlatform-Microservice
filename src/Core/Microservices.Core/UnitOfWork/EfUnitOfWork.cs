using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Microservices.Core.UnitOfWork
{
    public class EfUnitOfWork<TContext> : IUnitOfWork where TContext: DbContext
    {
        private readonly TContext _context;

        public EfUnitOfWork(TContext context)
        {
            _context = context;
        }

        public void CommitChanges()
        {
            this._context.SaveChanges();
        }

        public void Dispose()
        {
            this.Dispose();
        }
    }
}
