using FluentValidation;
using Microservice.Identity.Domain.ValidationErrorObjects;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace Mircoservice.Identity.API.Filter
{
    public class ValidationFilter : TypeFilterAttribute
    {
        public ValidationFilter():base(typeof(HandleValidationsFilter))
        {

        }    
    }


    public class HandleValidationsFilter : IActionFilter
    {
             
        public void OnActionExecuting(ActionExecutingContext context)
        {
            if (!context.ModelState.IsValid)
            {
                List<ValidationErrorDetail> validationErrorDetails = 
                    context.ModelState.Where(x => x.Value.Errors.Count > 0).Select(x => new ValidationErrorDetail(x.Key, x.Value.Errors.Select(x => x.ErrorMessage).ToList())).ToList();

                ValidationError validationError = new ValidationError(validationErrorDetails);

                //Will Handle In ExceptionHandler Middleware
                string logTrackId = context.HttpContext.Request.Headers["logTrackId"];
                throw new Microservice.Identity.Domain.Exception.ValidationException("Validation Error" ,validationError, logTrackId);
            }
        }


        public void OnActionExecuted(ActionExecutedContext context)
        {


        }
    }
}
