using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Microservice.Identity.Infrastructure.Model
{
    public class ClientToken : AccessToken
    {
        public string ClientId { get; set; }
    }
}
