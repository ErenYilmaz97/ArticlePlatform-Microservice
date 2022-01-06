using Microservices.Core.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Microservice.Identity.Domain.Entity
{
    public class Role : SoftDeletableEntity<string>
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public long PermissionGroupId { get; set; }


        #region Nav Props
        public virtual List<User> Users { get; set; }
        public virtual PermissionGroup PermissionGroup { get; set; }
        #endregion

    }
}
