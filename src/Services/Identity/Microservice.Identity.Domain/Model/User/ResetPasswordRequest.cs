using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Microservice.Identity.Domain.Model.User
{
    public class ResetPasswordRequest : RequestBase
    {
        public string UserId { get; set; }
        public string ResetPasswordToken { get; set; }
        public string NewPassword { get; set; }
        public string NewPasswordConfirm { get; set; }
    }
}
