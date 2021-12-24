using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Microservices.Core.Entity
{
    public class SoftDeletableEntity<TPrimaryKey> : Entity<TPrimaryKey> , ISoftDeletableEntity
    {
        public bool IsDeleted { get; set; }
    }
}
