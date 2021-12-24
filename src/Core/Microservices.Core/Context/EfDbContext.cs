using Microservices.Core.Entity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Microservices.Core.Context
{
    public class EfDbContext : DbContext
    {
        public EfDbContext(DbContextOptions<EfDbContext> opts):base(opts)
        {

        }


        //Sync
        public override int SaveChanges()
        {
            this.BeforeSaveChanges();
            return base.SaveChanges();
        }

        //Async
        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            this.BeforeSaveChanges();
            return base.SaveChangesAsync(cancellationToken);
        }


        private void BeforeSaveChanges()
        {
            ChangeTracker.DetectChanges();

            var entries = ChangeTracker.Entries().Where(x => x.State == EntityState.Deleted);

            foreach (var entry in entries)
            {
                if(entry is ISoftDeletableEntity entity)
                {
                    //Entity softdeletable ise softdelete, yoksa harddelete uygulanıyor.
                    entry.State = EntityState.Unchanged;
                    entity.IsDeleted = true;
                }
            }
        }
    }
}
