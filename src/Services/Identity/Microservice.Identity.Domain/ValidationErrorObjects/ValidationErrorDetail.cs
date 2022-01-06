using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Microservice.Identity.Domain.ValidationErrorObjects
{
    public class ValidationErrorDetail
    {
        public string FieldName { get; set; }
        public List<string> ValidationErrors { get; set; }


        public ValidationErrorDetail()
        {
            this.ValidationErrors = new List<string>();
        }


        public ValidationErrorDetail(string fieldName, List<string> validationErrors)
        {
            this.FieldName = fieldName;
            this.ValidationErrors = validationErrors;
        }
     
    }
}
