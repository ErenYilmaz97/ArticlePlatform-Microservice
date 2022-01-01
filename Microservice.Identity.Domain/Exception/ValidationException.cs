using Microservice.Identity.Domain.ValidationErrorObjects;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Microservice.Identity.Domain.Exception
{
    public class ValidationException : System.Exception
    {
        public ValidationError ValidationError { get; set; }
        public string Message { get; set; }

        public ValidationException(string message,ValidationError validationError)
        {
            this.Message = message;
            this.ValidationError = validationError;
        }


        public override string ToString()
        {
            return JsonConvert.SerializeObject(this);
        }
    }
}
