using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Microservice.Identity.Domain.Model.Identity
{
    public class RefreshTokenLoginRequest : RequestBase
    {
        public string UserId { get; set; }
        public string RefreshToken { get; set; }
    }
}
