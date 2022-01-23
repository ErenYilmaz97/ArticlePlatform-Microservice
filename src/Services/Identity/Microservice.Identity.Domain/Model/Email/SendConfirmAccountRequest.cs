using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Microservice.Identity.Domain.Model.Email
{
    public class SendConfirmAccountRequest : RequestBase
    {
        public string Email { get; set; }
    }
}
