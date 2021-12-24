using Microservices.Core.Entity;
using Microservices.Core.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Microservice.Identity.Domain.Entity
{
    public class Permission : SoftDeletableEntity<long>
    {
        public PermissionType PermissionType { get; set; }
        public string Description { get; set; }

        #region Nav Props
        public virtual List<PermissionGroup> PermissionGroups { get; set; }
        #endregion
    }
}
