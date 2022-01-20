using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Microservice.Identity.Domain.Exception
{
    public class BusinessException : System.Exception
    {
        public string LogTrackId { get; set; }
        public BusinessException(string message, string logTrackId):base(message)
        {
            this.LogTrackId = logTrackId;
        }


        public override string ToString()
        {
            return JsonConvert.SerializeObject(this);
        }
    }
}
