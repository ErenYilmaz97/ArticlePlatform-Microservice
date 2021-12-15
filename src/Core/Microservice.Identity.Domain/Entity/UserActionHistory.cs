using Microservice.Identity.Domain.Enum;
using Microservices.Identity.Domain.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Microservice.Identity.Domain.Entity
{
    public class UserActionHistory : SoftDeletableEntity<long>
    {
        public string UserId { get; set; }
        public UserActionType ActionType { get; set; }

        #region Navigation Props     
        public virtual User User { get; set; }
        #endregion
    }
}
