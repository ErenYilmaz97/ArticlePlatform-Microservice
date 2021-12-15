using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Microservice.User.Domain.Context
{
    public class UserDbContext : DbContext
    {
        public UserDbContext(DbContextOptions<UserDbContext> contextOptions):base(contextOptions)
        {

        }

        public UserDbContext()
        {

        }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=(localdb)\Eren;Database=XXXX;Trusted_Connection=True;MultipleActiveResultSets=True");
            base.OnConfiguring(optionsBuilder);
        }

        //TODO : Add SoftDelete Mechanism
    }
}
