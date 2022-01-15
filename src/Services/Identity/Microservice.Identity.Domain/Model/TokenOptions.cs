using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Microservice.Identity.Domain.Model
{
    public class TokenOptions
    {
        public string Audience { get; set; }
        public string Issuer { get; set; }
        public int UserAccessTokenExpiration { get; set; }
        public int ClientAccessTokenExpiration { get; set; }
        public string SecurityKey { get; set; }
    }
}
