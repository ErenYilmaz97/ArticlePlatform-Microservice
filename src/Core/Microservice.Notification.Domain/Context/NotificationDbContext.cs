using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Microservice.Notification.Domain
{
    public class NotificationDbContext : DbContext
    {
        public NotificationDbContext(DbContextOptions<NotificationDbContext> contextOptions):base(contextOptions)
        {

        }

        public NotificationDbContext()
        {

        }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseNpgsql(@"Server=(localdb)\Eren;Database=XXXX;Trusted_Connection=True;MultipleActiveResultSets=True");
        }

        //TODO: Add SoftDelete Mechanism
    }
}
