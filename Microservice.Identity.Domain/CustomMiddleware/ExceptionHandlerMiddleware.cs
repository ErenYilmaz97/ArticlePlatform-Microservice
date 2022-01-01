using Microservice.Identity.Domain.Exception;
using Microservice.Identity.Domain.Extension;
using Microsoft.AspNetCore.Http;
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

        public ExceptionHandlerMiddleware(RequestDelegate next)
        {
            _next = next;
        }


        public async Task InvokeAsync(HttpContext context)
        {
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
