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
        public BusinessException(string message):base(message)
        {

        }


        public override string ToString()
        {
            return JsonConvert.SerializeObject(this);
        }
    }
}
