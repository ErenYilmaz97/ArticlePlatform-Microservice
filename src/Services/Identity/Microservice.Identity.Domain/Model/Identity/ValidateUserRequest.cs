using Microservices.Core.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Microservice.Identity.Domain.Model.Identity
{
    public class ValidateUserRequest : RequestBase
    {
        public string UserId { get; set; }
        public PermissionType Permission { get; set; }
    }
}
