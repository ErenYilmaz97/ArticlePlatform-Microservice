using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Microservice.Identity.Domain.Model
{
    public abstract class RequestBase
    {
        public string LogTrackId { get; set; }
    }
}
