using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Microservice.Identity.Domain.ValidationErrorObjects
{
    public class ValidationError
    {
        public List<ValidationErrorDetail> ValidationErrors { get; }


        public ValidationError (List<ValidationErrorDetail> validaitonErrors)
        {
            this.ValidationErrors = validaitonErrors;
        }


        public override string ToString()
        {
            return JsonConvert.SerializeObject(this);
        }
    }
}
