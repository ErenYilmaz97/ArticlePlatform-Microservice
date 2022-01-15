using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Microservice.Identity.Domain.Model
{
    public class ClientToken : AccessToken
    {
        public string ClientId { get; set; }
    }
}
