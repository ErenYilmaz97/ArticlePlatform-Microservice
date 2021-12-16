using Microservices.Core.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Microservices.Core.Dtos
{
    public class ValidateUserRequest
    {
        public string UserId { get; set; }
        public PermissionType Permission { get; set; }
    }
}
