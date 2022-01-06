using Microservice.Identity.Domain.Enum;
using Microservices.Core.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Microservice.Identity.Domain.Entity
{
    public class User : SoftDeletableEntity<string>
    {
        public string Name { get; set; }
        public string LastName { get; set; }
        public Gender Gender { get; set; }
        public string PictureName { get; set; }
        public byte[] PasswordSalt { get; set; }
        public byte[] PasswordHash { get; set; }
        public string Email { get; set; }
        public bool EmailConfirmed { get; set; }
        public DateTime? EmailConfirmedDate { get; set; }
        public DateTime LastLoginDate { get; set; }
        public DateTime? LastPasswordUpdatedDate { get; set; }
        public bool IsPasswordExpired { get; set; }


        #region Nav Props
        public virtual List<Role> Roles { get; set; }
        public virtual List<LoginHistory> LoginHistories { get; set; }
        public virtual List<UserCommonToken> CommonTokens { get; set; }
        public virtual List<UserActionHistory> ActionHistories { get; set; }

        #endregion
    }
}
