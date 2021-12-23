using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Microservices.Core.Entity
{
    internal interface ISoftDeletableEntity<TPrimaryKey> : IEntity<TPrimaryKey>
    {
        public bool IsDeleted { get; set; }
    }
}
