using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microservices.Core.Entity;

namespace Microservice.Identity.Domain.Entity
{
    //PermissionGroup Kayıtlarına HardDelete Uygulanmalı
    public class PermissionGroup : Entity<long>
    {
        #region Nav Props
        public virtual Role Role { get; set; }
        public virtual List<Permission> Permissions { get; set; }
        #endregion
    }
}
