using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Microservices.Identity.Domain.Entity
{
    internal interface ISoftDeletableEntity<TId>:IEntity<TId>
    {
        public bool IsDeleted { get; set; }
    }
}
