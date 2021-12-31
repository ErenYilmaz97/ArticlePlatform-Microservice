using Microservice.Identity.Domain.Enum;
using Microservices.Core.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace Microservice.Identity.Domain.Entity
{
    //UserCommonToken Kayıtlarına HardDelete Uygulanmalı
    public class UserCommonToken : Entity<long>
    {
        public string UserId { get; set; }
        public TokenType TokenType { get; set; }
        public string Value { get; set; }
        public DateTime ExpireDate { get; set; }
        public bool IsValid { get; set; }


        #region Nav Props
        public virtual User User { get; set; }
        #endregion
    }
}
