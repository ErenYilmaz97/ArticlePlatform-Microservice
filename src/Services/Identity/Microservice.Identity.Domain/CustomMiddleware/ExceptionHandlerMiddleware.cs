using Microservice.Identity.Domain.Exception;
using Microservice.Identity.Domain.Extension;
using Microservices.Core.CrossCuttingConcerns.Logging;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Microservice.Identity.Domain.CustomMiddleware
{
    public class ExceptionHandlerMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger<ExceptionHandlerMiddleware> _logger;

        public ExceptionHandlerMiddleware(RequestDelegate next, ILogger<ExceptionHandlerMiddleware> logger)
        {
            _next = next;
            _logger = logger;
        }


        public async Task InvokeAsync(HttpContext context)
        {
            //Can not be null
            string logTrackId = context.Request.Headers["logTrackId"];

            try
            {
                await _next(context);
            }
            catch (System.Exception ex)
            {
                await HandleExceptionAsync(context, ex, logTrackId);
            }
        }


        private Task HandleExceptionAsync(HttpContext context, System.Exception ex, string logTrackId)
        {          
            if (ex is ValidationException validationException)
            {
                this._logger.LogError("Validation Error Occurred. {@errorLogObject}", new LogObject(validationException.ValidationError.ToString(), logTrackId));
                return context.Response.ReturnValidationErrorResponse(validationException);
            }

            if(ex is BusinessException businessException)
            {
                this._logger.LogError("Business Error Occurred. {@errorLogObject}", new LogObject(businessException.Message, logTrackId));
                return context.Response.ReturnBusinessErrorResponse(businessException);
            }

            this._logger.LogError("Unexpected Error Occurred. {@errorLogObject}", new LogObject(ex.Message, logTrackId));
            return context.Response.InternalServerErrorResponse(ex);
        }
    }
}
