using Microservices.Identity.Domain.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Microservice.Identity.Domain.Entity
{
    public class PermissionGroup : SoftDeletableEntity<long>
    {
        #region Navigation Props
        public virtual Role Role { get; set; }
        public virtual List<Permission> Permissions { get; set; }
        #endregion
    }
}
