using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Microservice.Chat.Domain.Context
{
    public class ChatDbContext : DbContext
    {
        public ChatDbContext(DbContextOptions<ChatDbContext> contextOptions):base(contextOptions)
        {

        }

        public ChatDbContext()
        {

        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseNpgsql(@"Server=(localdb)\Eren;Database=XXXX;Trusted_Connection=True;MultipleActiveResultSets=True");
        }

        //TODO: Add SoftDelete Mechanism
    }
}
