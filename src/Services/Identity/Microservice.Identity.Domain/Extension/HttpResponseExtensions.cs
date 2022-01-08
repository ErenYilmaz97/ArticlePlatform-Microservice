using Microservice.Identity.Domain.Exception;
using Microservice.Identity.Domain.ValidationErrorObjects;
using Microservices.Core.Utilities.Result;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Microservice.Identity.Domain.Extension
{
    public static class HttpResponseExtensions
    {
        public static Task ReturnValidationErrorResponse(this HttpResponse response, ValidationException exception)
        {
            response.StatusCode = 400;
            response.ContentType = "application/json";
            ControllerResponse<ValidationError> responseObject = new() { ResultCode = ResultCodes.Failed, ResultMessage = exception.Message , Data = exception.ValidationError}; 

            return response.WriteAsync(responseObject.ToString());
        }



        public static Task ReturnBusinessErrorResponse(this HttpResponse response, BusinessException exception)
        {
            response.StatusCode = 400;
            response.ContentType = "application/json";
            ControllerResponse<object> responseObject = new() { ResultCode = ResultCodes.Failed, ResultMessage = exception.Message };

            return response.WriteAsync(responseObject.ToString());
        }



        public static Task InternalServerErrorResponse(this HttpResponse httpResponse, System.Exception exception)
        {
            httpResponse.StatusCode = 400;
            httpResponse.ContentType = "application/json";
            ControllerResponse<object> responseObject = new() { ResultCode = ResultCodes.Failed, ResultMessage = exception.Message};
            return httpResponse.WriteAsync(responseObject.ToString());
        }
    }
}
