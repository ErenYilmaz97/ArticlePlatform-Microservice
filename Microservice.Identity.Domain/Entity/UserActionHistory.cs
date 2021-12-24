using Microservice.Identity.Domain.Enum;
using Microservices.Core.Entity;
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
        public ActionType ActionType { get; set; }


        #region Nav Props
        public virtual User User { get; set; }
        #endregion
    }
}
