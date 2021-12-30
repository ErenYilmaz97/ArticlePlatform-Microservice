using Microservice.Identity.Domain.ValidationErrorObjects;
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

        public ValidationException(ValidationError validationError)
        {
            this.ValidationError = validationError;
        }

        public ValidationException()
        {

        }
    }
}
