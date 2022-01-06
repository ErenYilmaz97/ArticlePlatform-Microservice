using Microservice.Identity.Domain.Exception;
using Microservice.Identity.Domain.Extension;
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
                await HandleExceptionAsync(context, ex);
            }
        }


        private Task HandleExceptionAsync(HttpContext context, System.Exception ex)
        {
            this._logger.LogError(ex.Message);
            this._logger.LogError("{@exception}", ex);

            if (ex is ValidationException validationException)
            {
                return context.Response.ReturnValidationErrorResponse(validationException);
            }

            if(ex is BusinessException businessException)
            {
                return context.Response.ReturnBusinessErrorResponse(businessException);
            }


            return context.Response.InternalServerErrorResponse();
        }
    }
}
