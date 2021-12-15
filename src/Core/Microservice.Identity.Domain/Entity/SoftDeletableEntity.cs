using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Microservices.Identity.Domain.Entity
{
    public class SoftDeletableEntity<TId> :Entity<TId>, ISoftDeletableEntity<TId>
    {
        public bool IsDeleted { get; set; }
    }
}
