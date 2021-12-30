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
        public string Message { get; set; }
        public int StatusCode { get; set; }


        public ValidationError(string message, int statusCode, List<ValidationErrorDetail> validaitonErrors)
        {
            this.Message = message;
            this.StatusCode = statusCode;
            this.ValidationErrors = validaitonErrors;
        }
    }
}
