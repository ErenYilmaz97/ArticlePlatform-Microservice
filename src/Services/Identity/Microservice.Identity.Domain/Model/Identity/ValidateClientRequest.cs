﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Microservice.Identity.Domain.Model.Identity
{
    public class ValidateClientRequest : RequestBase
    {
        public string ClientId { get; set; }
        public string ClientSecret { get; set; }
    }
}
