﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Microservice.Identity.Domain.Model.User
{
    public class ConfirmEmailRequest : RequestBase
    {
        public string UserId { get; set; }
        public string ConfirmEmailToken { get; set; }
    }
}
