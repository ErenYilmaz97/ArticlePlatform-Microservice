using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Microservice.Identity.Domain.Context
{
    public class IdentityDbContext : DbContext
    {
        public IdentityDbContext(DbContextOptions<IdentityDbContext> contextOptions):base(contextOptions)
        {

        }

        public IdentityDbContext()
        {

        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=(localdb)\Eren;Database=XXXX;Trusted_Connection=True;MultipleActiveResultSets=True");
            base.OnConfiguring(optionsBuilder);
        }

        //TODO : ADD SOFTDELETE MECHANISM
    }
}
