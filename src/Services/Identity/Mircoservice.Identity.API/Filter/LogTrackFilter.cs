using Microsoft.AspNetCore.Mvc.Filters;

namespace Mircoservice.Identity.API.Filter
{
    public class LogTrackFilter : IActionFilter
    {
        public void OnActionExecuted(ActionExecutedContext context)
        {
            string logTrackId = context.HttpContext.Request.Headers["logTrackId"];

            if (string.IsNullOrEmpty(logTrackId))
            {
                throw new ApplicationException("There is no LogTrackId in the request header.");
            }
        }

        public void OnActionExecuting(ActionExecutingContext context)
        {
            
        }
    }
}
